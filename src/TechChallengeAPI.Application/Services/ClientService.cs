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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ClientDto> _validator;

        public ClientService(IClientRepository clientRepository,
                          IValidator<ClientDto> validator,
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

            var clientMapped = _mapper.Map<Client>(client);

            _clientRepository.Delete(clientMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Client>>> GetClient()
        {
            return new BaseOutput<IList<Client>>((await _clientRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Client>> GetIdClientById(int id)
        {
            var response = new BaseOutput<Client>();

            response.Response = await _clientRepository.GetAsync(id);

            return response;
        }

 
        public async Task<BaseOutput<int>> Register(ClientDto client)
        {
            var response = new BaseOutput<int>();

            ValidationUtil.ValidateClass(client, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var clientMapped = _mapper.Map<Client>(client);

            await _clientRepository.AddAsync(clientMapped);

            await _unitOfWork.CommitAsync();

            response.Response = client.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ClientDto client)
        {
            var response = new BaseOutput<bool>();

            ValidationUtil.ValidateClass(client, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var clientMapped = _mapper.Map<Client>(client);

            _clientRepository.Update(clientMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }

    }
}
