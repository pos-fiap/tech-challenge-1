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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<VehicleDto> _validator;

        public VehicleService(IVehicleRepository vehicleRepository,
                          IValidator<VehicleDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Vehicle vehicle = await _vehicleRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (vehicle is null)
            {
                response.AddError("Id de vehiclero não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Vehicle vehicleMapped = _mapper.Map<Vehicle>(vehicle);

            _vehicleRepository.Delete(vehicleMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Vehicle>>> GetVehicle()
        {
            return new BaseOutput<IList<Vehicle>>((await _vehicleRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Vehicle>> GetVehicle(int id)
        {
            BaseOutput<Vehicle> response = new BaseOutput<Vehicle>
            {
                Response = await _vehicleRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(VehicleDto vehicle)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(vehicle, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Vehicle vehicleMapped = _mapper.Map<Vehicle>(vehicle);

            await _vehicleRepository.AddAsync(vehicleMapped);

            await _unitOfWork.CommitAsync();

            response.Response = vehicle.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(VehicleDto vehicle)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(vehicle, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Vehicle vehicleMapped = _mapper.Map<Vehicle>(vehicle);

            _vehicleRepository.Update(vehicleMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }
    }
}
