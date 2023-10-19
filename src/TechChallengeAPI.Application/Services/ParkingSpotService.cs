using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class ParkingSpotService : IParkingSpotService
    {
        private readonly IParkingSpotRepository _parkingSpotRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ParkingSpotDto> _validator;

        public ParkingSpotService(IParkingSpotRepository parkingRepository,
            IReservationRepository reservationRepository,
                              IValidator<ParkingSpotDto> validator,
                              IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _validator = validator;
            _parkingSpotRepository = parkingRepository;
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            ParkingSpot parking = await _parkingSpotRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (parking is null)
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            ParkingSpot parkingMapped = _mapper.Map<ParkingSpot>(parking);

            _parkingSpotRepository.Delete(parkingMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<BaseOutput<IList<ParkingSpot>>> Get()
        {
            return new BaseOutput<IList<ParkingSpot>>((await _parkingSpotRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<IList<ParkingSpot>>> GetAllFreeParkingSpots()
        {
            IEnumerable<Reservation> notFinishedReservations = await _reservationRepository.GetAsync(x => x.Finished == false, true);
            IEnumerable<ParkingSpot> parkingSpots = await _parkingSpotRepository.GetAsync();

            //parkingSpots.Where(x => !notFinishedReservations.Select(x => x.ParkingSpotId).Contains(x.Id));

            return new BaseOutput<IList<ParkingSpot>>(parkingSpots.Where(x => !notFinishedReservations.Any(y => y.ParkingSpotId != x.Id)).ToList());
        }

        public async Task<BaseOutput<ParkingSpot>> Get(int id)
        {
            BaseOutput<ParkingSpot> response = new()
            {
                Response = await _parkingSpotRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Create(ParkingSpotDto parking)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(parking, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            ParkingSpot parkingMapped = _mapper.Map<ParkingSpot>(parking);

            await _parkingSpotRepository.AddAsync(parkingMapped);
            await _unitOfWork.CommitAsync();

            response.Response = parkingMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ParkingSpotDto parking)
        {
            BaseOutput<bool> response = new();

            ParkingSpot parkingMapped = _mapper.Map<ParkingSpot>(parking);

            if (!await VerifyParkingSpot(parkingMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _parkingSpotRepository.Update(parkingMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<bool> VerifyParkingSpot(int Id)
        {
            return await _parkingSpotRepository.ExistsAsync(x => x.Id == Id);
        }
    }
}