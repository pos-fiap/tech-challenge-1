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
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerDto> _validator;

        public CustomerService(ICustomerRepository customerRepository,
                          IPersonRepository personRepository,
                          IValidator<CustomerDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _personRepository = personRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseOutput<IList<Customer>>> Get()
        {
            return new BaseOutput<IList<Customer>>((await _customerRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Customer>> GetById(int id)
        {
            BaseOutput<Customer> response = new()
            {
                Response = await _customerRepository.GetAsync(id)
            };

            return response;
        }


        public async Task<BaseOutput<int>> Create(CustomerDto customer)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(customer, _validator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(customer.PersonalInformations.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Customer CustomerMapped = _mapper.Map<Customer>(customer);

            await _customerRepository.AddAsync(CustomerMapped);
            await _unitOfWork.CommitAsync();

            response.Response = CustomerMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(CustomerDto customer)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(customer, _validator, response);

            //IList<Person> person = _personRepository.GetPersonByDocument(customer.PersonalInformations.Document);

            //if (person.Any())
            //{
            //    response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            //}

            Customer CustomerMapped = _mapper.Map<Customer>(customer);

            if (!await VerifyUser(CustomerMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _customerRepository.Update(CustomerMapped);
            await _unitOfWork.CommitAsync();

            response.Response = false;

            return response;
        }

        public async Task<bool> VerifyUser(int Id)
        {
            return await _customerRepository.ExistsAsync(x => x.Id == Id);
        }

    }
}
