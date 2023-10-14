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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ParkingSpotDto> _validator;

        public ParkingSpotService(IParkingSpotRepository parkingRepository,
                              IValidator<ParkingSpotDto> validator,
                              IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _validator = validator;
            _parkingSpotRepository = parkingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            ParkingSpot parking = await _parkingSpotRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (parking is null)
            {
                response.AddError("Id de vehiclero não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            ParkingSpot parkingMapped = _mapper.Map<ParkingSpot>(parking);

            _parkingSpotRepository.Delete(parkingMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<ParkingSpot>>> GetParking()
        {
            return new BaseOutput<IList<ParkingSpot>>((await _parkingSpotRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<ParkingSpot>> GetParking(int id)
        {
            BaseOutput<ParkingSpot> response = new()
            {
                Response = await _parkingSpotRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(ParkingSpotDto parking)
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

            return new BaseOutput<int>(parking.Id);
        }

        public async Task<BaseOutput<bool>> Update(ParkingSpotDto parking)
        {
            ParkingSpot parkingMapped = _mapper.Map<ParkingSpot>(parking);

            _parkingSpotRepository.Update(parkingMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }
    }
}