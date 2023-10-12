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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerDto> _validator;

        public CustomerService(ICustomerRepository customerRepository,
                          IValidator<CustomerDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseOutput<bool>> Delete(int id)
        {
            var response = new BaseOutput<bool>();

            var Customer = await _customerRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (Customer is null)
            {
                response.AddError("Id de Customerro não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var CustomerMapped = _mapper.Map<Customer>(Customer);

            _customerRepository.Delete(CustomerMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Customer>>> GetCustomer()
        {
            return new BaseOutput<IList<Customer>>((await _customerRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Customer>> GetIdCustomerById(int id)
        {
            var response = new BaseOutput<Customer>();

            response.Response = await _customerRepository.GetAsync(id);

            return response;
        }

 
        public async Task<BaseOutput<int>> Register(CustomerDto Customer)
        {
            var response = new BaseOutput<int>();

            ValidationUtil.ValidateClass(Customer, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var CustomerMapped = _mapper.Map<Customer>(Customer);

            await _customerRepository.AddAsync(CustomerMapped);

            await _unitOfWork.CommitAsync();

            response.Response = Customer.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(CustomerDto Customer)
        {
            var response = new BaseOutput<bool>();

            ValidationUtil.ValidateClass(Customer, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var CustomerMapped = _mapper.Map<Customer>(Customer);

            _customerRepository.Update(CustomerMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }

    }
}
