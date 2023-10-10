using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Interfaces
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
            var response = new BaseOutput<bool>();

            var valet = await _valetRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (valet is null)
            {
                response.AddError("Id de carro não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var valetMapped = _mapper.Map<Valet>(valet);

            _valetRepository.Delete(valetMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Valet>>> GetValet()
        {
            return new BaseOutput<IList<Valet>>((await _valetRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<Valet>> GetValetById(int id)
        {
            var response = new BaseOutput<Valet>();

            response.Response = await _valetRepository.GetAsync(id);

            return response;
        }

        public async Task<BaseOutput<int>> Register(ValetDto valet)
        {
            var response = new BaseOutput<int>();

            ValidationUtil.ValidateClass(valet, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var valetMapped = _mapper.Map<Valet>(valet);;

            await _valetRepository.AddAsync(valetMapped);

            await _unitOfWork.CommitAsync();

            response.Response = valet.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ValetDto valet)
        {
            var response = new BaseOutput<bool>();

            ValidationUtil.ValidateClass(valet, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var valetMapped = _mapper.Map<Valet>(valet);;

            _valetRepository.Update(valetMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }
    }
}