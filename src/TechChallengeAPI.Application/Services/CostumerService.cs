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
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CostumerDto> _validator;

        public CostumerService(ICostumerRepository clientRepository,
                          IValidator<CostumerDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseOutput<bool>> Delete(int id)
        {
            var response = new BaseOutput<bool>();

            var client = await _clientRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (client is null)
            {
                response.AddError("Id de clientro não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var clientMapped = _mapper.Map<Costumer>(client);

            _clientRepository.Delete(clientMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Costumer>>> GetCostumer()
        {
            return new BaseOutput<IList<Costumer>>((await _clientRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Costumer>> GetIdCostumer(int id)
        {
            var response = new BaseOutput<Costumer>();

            response.Response = await _clientRepository.GetAsync(id);

            return response;
        }

 
        public async Task<BaseOutput<int>> Register(CostumerDto client)
        {
            var response = new BaseOutput<int>();

            ValidationUtil.ValidateClass(client, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var clientMapped = _mapper.Map<Costumer>(client);

            await _clientRepository.AddAsync(clientMapped);

            await _unitOfWork.CommitAsync();

            response.Response = client.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(CostumerDto client)
        {
            var response = new BaseOutput<bool>();

            ValidationUtil.ValidateClass(client, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var clientMapped = _mapper.Map<Costumer>(client);

            _clientRepository.Update(clientMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }

    }
}
