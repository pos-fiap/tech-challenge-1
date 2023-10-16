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
    public class CustomerVehicleService : ICustomerVehicleService
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerVehicleDto> _validator;

        public CustomerVehicleService(ICustomerVehicleRepository customerVehicleRepository,
                          IValidator<CustomerVehicleDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _customerVehicleRepository = customerVehicleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            CustomerVehicle customerVehicle = await _customerVehicleRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (customerVehicle is null)
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            CustomerVehicle customerVehicleMapped = _mapper.Map<CustomerVehicle>(customerVehicle);

            _customerVehicleRepository.Delete(customerVehicleMapped);
            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<CustomerVehicle>>> GetCustomerVehicle()
        {
            return new BaseOutput<IList<CustomerVehicle>>((await _customerVehicleRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<CustomerVehicle>> GetCustomerVehicle(int id)
        {
            BaseOutput<CustomerVehicle> response = new BaseOutput<CustomerVehicle>
            {
                Response = await _customerVehicleRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(CustomerVehicleDto customerVehicle)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(customerVehicle, _validator, response);

            IEnumerable<CustomerVehicle> dbCustomerVehicle = await _customerVehicleRepository.GetAsync(x => (x.CustomerId == customerVehicle.CustomerId || x.PersonId == customerVehicle.PersonId) && x.VehicleId == customerVehicle.VehicleId, true);

            if (dbCustomerVehicle.Any())
            {
                response.AddError($"This Customer/Person already have a connection with this Vehicle");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            CustomerVehicle customerVehicleMapped = _mapper.Map<CustomerVehicle>(customerVehicle);

            await _customerVehicleRepository.AddAsync(customerVehicleMapped);
            await _unitOfWork.CommitAsync();

            response.Response = customerVehicle.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(CustomerVehicleDto customerVehicle)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(customerVehicle, _validator, response);

            CustomerVehicle customerVehicleMapped = _mapper.Map<CustomerVehicle>(customerVehicle);

            if (!await VerifyCustomerVehicle(customerVehicleMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _customerVehicleRepository.Update(customerVehicleMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<bool> VerifyCustomerVehicle(int Id)
        {
            return await _customerVehicleRepository.ExistsAsync(x => x.Id == Id);
        }
    }
}
