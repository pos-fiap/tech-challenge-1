using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Application.Utils;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Domain.Interfaces;

namespace RCLocacoes.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AddressDto> _addressDtoValidator;

        public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddressDto> addressDtoValidator)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addressDtoValidator = addressDtoValidator;
        }


        public async Task<BaseOutput<List<Address>>> GetAll()
        {
            var response = new BaseOutput<List<Address>>();

            IEnumerable<Address> addresses = await _addressRepository.GetAsync();

            response.IsSuccessful = addresses.Any();
            response.Response = addresses.ToList();

            return response;
        }

        public async Task<BaseOutput<int>> RegisterAddress(AddressDto addressDto)
        {
            var response = new BaseOutput<int>();

            ValidationUtil.ValidateClass(addressDto, _addressDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var addressMapped = _mapper.Map<Address>(addressDto);
            await _addressRepository.AddAsync(addressMapped);
            await _unitOfWork.CommitAsync();

            response.Response = addressMapped.Id;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<bool> VerifyAddress(int Id)
        {
            var entityExists = await _addressRepository.ExistsAsync(x => x.Id == Id);

            return entityExists;
        }

        public async Task<BaseOutput<bool>> DeleteAddress(int Id)
        {
            var response = new BaseOutput<bool>();
            var address = new Address { Id = Id };

            if (!await VerifyAddress(address.Id))
            {
                response.IsSuccessful = false;
                response.Response = false;
                response.AddError("Not Found");
            }

            _addressRepository.Delete(address);
            await _unitOfWork.CommitAsync();

            response.Response = true;
            response.IsSuccessful = true;

            return response;
        }
    }
}
