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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserRoleDto> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository,
                               IUserRepository userRepository,
                               IValidator<UserRoleDto> validator,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<int>> AssignRoleToUser(UserRoleDto userRoleDto)
        {

            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(userRoleDto, _validator, response);

            if (!await _userRepository.ExistsAsync(exp => exp.Id == userRoleDto.UserId))
            {
                response.AddError("Id de usuário não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            //TODO: ACRESCENTAR VALIDAÇÃO DE EXISTÊNCIA DO ID DA ROLE

            IEnumerable<UserRole> actualRole = await _userRoleRepository.GetAsync(x => x.UserId == userRoleDto.UserId, true);

            List<UserRole> userRoleMapped = _mapper.Map<IEnumerable<UserRole>>(userRoleDto).ToList();

            IEnumerable<UserRole> includedRoles = userRoleMapped.Where(x => !actualRole.Select(y => y.RoleId).Contains(x.RoleId));

            IEnumerable<UserRole> deletedRoles = actualRole.Where(x => !userRoleMapped.Select(y => y.RoleId).Contains(x.RoleId));

            if (deletedRoles.Any()) RemoveDeletedRoles(deletedRoles);

            if (includedRoles.Any()) AddIncludedRoles(includedRoles);

            await _unitOfWork.CommitAsync();

            response.Response = userRoleMapped.First().Id;

            return response;
        }

        public async Task<BaseOutput<UserRole>> GetByUser(int user)
        {
            BaseOutput<UserRole> response = new();

            if (!await _userRepository.ExistsAsync(exp => exp.Id == user))
            {
                response.AddError("Id de usuário não econtrado!");
                return response;
            }

            response.Response = await _userRoleRepository.GetAsync(user);

            return response;
        }

        private async void AddIncludedRoles(IEnumerable<UserRole> userRoles)
        {
            await _userRoleRepository.AddAsync(userRoles.ToList());
        }

        private void RemoveDeletedRoles(IEnumerable<UserRole> userRoles)
        {
            _userRoleRepository.Delete(userRoles.ToList());
        }
    }
}
