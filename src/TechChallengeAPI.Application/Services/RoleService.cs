using AutoMapper;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Role> GetRole(int Id)
        {
            return await _roleRepository.GetAsync(Id);
        }

        public async Task<BaseOutput<int>> RegisterRole(RoleDto roleDto)
        {
            var response = new BaseOutput<int>();

            var roleMapped = _mapper.Map<Role>(roleDto);
            await _roleRepository.AddAsync(roleMapped);
            await _unitOfWork.CommitAsync();

            response.Response = roleMapped.Id;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<bool> VerifyRole(RoleDto roleDto)
        {
            return await _roleRepository.ExistsAsync(x => x.Description == roleDto.Description);
        }
    }
}
