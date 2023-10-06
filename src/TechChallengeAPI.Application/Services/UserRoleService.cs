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
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository, 
                               IUserRepository userRepository,
                               IUnitOfWork unitOfWork, 
                               IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> AssignRoleToUser(UserRoleDto userRoleDto)
        {
            var response = new BaseOutput<bool>();

            if (await _userRepository.ExistsAsync(exp => exp.Id == userRoleDto.Id))
            {
                response.AddError("Id de usuário não econtrado!");
            }

            //TODO: ACRESCENTAR VALIDAÇÃO DE EXISTÊNCIA DO ID DA ROLE

            IEnumerable<UserRole> userRoleMapped = _mapper.Map<IEnumerable<UserRole>>(userRoleDto);

            await _userRoleRepository.AddAsync(userRoleMapped.ToList());

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<UserRole>> GetRolesByUser(int user)
        {
            var response = new BaseOutput<UserRole>();

            if (await _userRepository.ExistsAsync(exp => exp.Id == user)) 
            {
                response.AddError("Id de usuário não econtrado!");
                return response;
            }

            response.Response = await _userRoleRepository.GetSingleAsync(exp => exp.UserId == user, false);

            return response;
        }

        public async Task<BaseOutput<bool>> UnassignRoleToUser(UserRoleDto userRoleDto)
        {
            var response = new BaseOutput<bool>();

            if (await _userRepository.ExistsAsync(exp => exp.Id == userRoleDto.Id))
            {
                response.AddError("Id de usuário não econtrado!");
            }

            //TODO: ACRESCENTAR VALIDAÇÃO DE EXISTÊNCIA DO ID DA ROLE

            IEnumerable<UserRole> userRoleMapped = _mapper.Map<IEnumerable<UserRole>>(userRoleDto);

            await _userRoleRepository.AddAsync(userRoleMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }
    }
}
