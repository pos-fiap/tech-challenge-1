using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Models;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        
        private readonly IValidator<PersonDTO> _personDtoValidator;

        public PersonService(IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<PersonDTO> personDtoValidator)
        {          
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _personDtoValidator = personDtoValidator;            
        }

        public async Task<BaseOutput<List<Person>>> GetAllPersons()
        {
            BaseOutput<List<Person>> response = new();

            IEnumerable<Person> persons = await _personRepository.GetAsync();

            response.Response = persons.ToList();

            return response;
        }
        public async Task<BaseOutput<Person>> GetPerson(int Id)
        {
            Person person = await _personRepository.GetAsync(Id);

            BaseOutput<Person> response = new()
            {
                Response = person
            };

            return response;
        }

        public async Task<BaseOutput<Person>> GetPerson(PersonDTO personDto)
        {
            BaseOutput<Person> response = new();

            var validationResult = _personDtoValidator.Validate(personDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<Person> persons = await _personRepository.GetAsync(x => x.Name == personDto.Name, true);

            response.Response = persons.FirstOrDefault() ?? new Person();
            return response;
        }


        public async Task<BaseOutput<int>> RegisterPerson(PersonDTO personDto)
        {

            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(personDto, _personDtoValidator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(personDto.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

         
            Person personMapped = _mapper.Map<Person>(personDto);

            await _personRepository.AddAsync(personMapped);
            await _unitOfWork.CommitAsync();

            response.Response = personMapped.Id;

            return response;
        }

        public async Task<BaseOutput<Person>> UpdatePerson(PersonDTO personDto)
        {
            BaseOutput<Person> response = new();

            ValidationUtil.ValidateClass(personDto, _personDtoValidator, response);

            //TODO: Criar verificação para a alteração de documento

            IList<Person> person = _personRepository.GetPersonByDocument(personDto.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            Person personMapped = _mapper.Map<Person>(personDto);

            if (!await VerifyPerson(personMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _personRepository.Update(personMapped);
            await _unitOfWork.CommitAsync();

            response.Response = personMapped;

            return response;
        }

        public async Task<BaseOutput<bool>> DeletePerson(int Id)
        {
            BaseOutput<bool> response = new();

            Person person = new() { Id = Id };

            if (!await VerifyPerson(person.Id))
            {
                response.AddError("Not Found");
            }

            _personRepository.Delete(person);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<bool> VerifyPerson(string name)
        {
            return await _personRepository.ExistsAsync(x => x.Name == name);
        }

        public async Task<bool> VerifyPerson(int Id)
        {
            return await _personRepository.ExistsAsync(x => x.Id == Id);
        }

      

        public Task<Person> GetPerson(string name)
        {
            return _personRepository.GetSingleAsync(x => x.Name == name, true);
        }

    }
}
