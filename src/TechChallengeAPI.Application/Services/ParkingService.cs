using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Interfaces
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ParkingDto> _validator;

        public ParkingService(IParkingRepository parkingRepository,
                              IValidator<ParkingDto> validator,
                              IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _validator = validator;
            _parkingRepository = parkingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Parking? parking = await _parkingRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (parking is null)
            {
                response.AddError("Id de carro não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Parking parkingMapped = _mapper.Map<Parking>(parking);

            _parkingRepository.Delete(parkingMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Parking>>> GetParking()
        {
            return new BaseOutput<IList<Parking>>((await _parkingRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Parking>> GetParking(int id)
        {
            BaseOutput<Parking> response = new()
            {
                Response = await _parkingRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(ParkingDto parking)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(parking, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Parking parkingMapped = _mapper.Map<Parking>(parking); ;

            await _parkingRepository.AddAsync(parkingMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<int>(parking.Id);
        }

        public async Task<BaseOutput<bool>> Update(ParkingDto parking)
        {
            Parking parkingMapped = _mapper.Map<Parking>(parking); ;

            _parkingRepository.Update(parkingMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }
    }
}