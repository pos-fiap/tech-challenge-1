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
    public class ValetService : IValetService
    {
        private readonly IValetRepository _valetRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ValetDto> _validator;

        public ValetService(IValetRepository valetRepository,
                            IPersonRepository personRepository,
                            IValidator<ValetDto> validator,
                            IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _validator = validator;
            _personRepository = personRepository;
            _valetRepository = valetRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Valet valet = await _valetRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (valet is null)
            {
                response.AddError("Valet not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Valet valetMapped = _mapper.Map<Valet>(valet);

            _valetRepository.Delete(valetMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<BaseOutput<IList<Valet>>> Get()
        {
            return new BaseOutput<IList<Valet>>((await _valetRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<Valet>> Get(int id)
        {
            BaseOutput<Valet> response = new()
            {
                Response = await _valetRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Create(ValetDto valet)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(valet, _validator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(valet.PersonalInformations.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Valet> dbValets = await _valetRepository.GetAsync(x => x.CNH == valet.CNH, true);

            if (dbValets.Any())
            {
                response.AddError($"There is an valet with the CNH provided.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Valet valetMapped = _mapper.Map<Valet>(valet);

            await _valetRepository.AddAsync(valetMapped);
            await _unitOfWork.CommitAsync();

            response.Response = valetMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ValetDto valet)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(valet, _validator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(valet.PersonalInformations.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            Valet valetMapped = _mapper.Map<Valet>(valet);

            if (!await VerifyUser(valetMapped.Id))
            {
                response.AddError("Not Found");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _valetRepository.Update(valetMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }
        public async Task<bool> VerifyUser(int Id)
        {
            return await _valetRepository.ExistsAsync(x => x.Id == Id);
        }
    }
}