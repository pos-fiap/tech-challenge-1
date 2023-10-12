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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ValetDto> _validator;

        public ValetService(IValetRepository valetRepository,
                            IValidator<ValetDto> validator,
                            IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _validator = validator;
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
                response.AddError("Car not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Valet valetMapped = _mapper.Map<Valet>(valet);

            _valetRepository.Delete(valetMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Valet>>> GetValet()
        {
            return new BaseOutput<IList<Valet>>((await _valetRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<Valet>> GetValet(int id)
        {
            BaseOutput<Valet> response = new()
            {
                Response = await _valetRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(ValetDto valet)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(valet, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var valetMapped = _mapper.Map<Valet>(valet);

            await _valetRepository.AddAsync(valetMapped);

            await _unitOfWork.CommitAsync();

            response.Response = valet.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ValetDto valet)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(valet, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Valet valetMapped = _mapper.Map<Valet>(valet);

            _valetRepository.Update(valetMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }
    }
}