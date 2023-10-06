using AutoMapper;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> AssignRoleToUser(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseOutput<UserRole>> GetRolesByUser(int user)
        {
            return new BaseOutput<UserRole>(await _userRoleRepository.GetSingleAsync(exp => exp.UserId == user, false));
        }

        public async Task<BaseOutput<bool>> UnassignRoleToUser(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }
    }
}
