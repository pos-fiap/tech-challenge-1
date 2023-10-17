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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<RoleDto> _roleDtoValidator;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<RoleDto> roleDtoValidator)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleDtoValidator = roleDtoValidator;
        }

        public async Task<BaseOutput<List<Role>>> GetAll()
        {
            BaseOutput<List<Role>> response = new();

            IEnumerable<Role> roles = await _roleRepository.GetAsync();

            response.IsSuccessful = true;
            response.Response = roles.ToList();

            return response;
        }

        public async Task<BaseOutput<Role>> Get(int Id)
        {
            Role role = await _roleRepository.GetAsync(Id);

            BaseOutput<Role> response = new()
            {
                IsSuccessful = true,
                Response = role
            };

            return response;
        }

        public async Task<List<int>> VerifyList(List<int> ListId)
        {
            List<int> listNoId = new();
            foreach (int Id in ListId)
            {
                if (!await Verify(Id))
                {
                    listNoId.Add(Id);
                }
            }
            return listNoId;
        }

        public async Task<BaseOutput<Role>> Get(RoleDto roleDto)
        {
            IEnumerable<Role> roles = await _roleRepository.GetAsync(x => x.Description == roleDto.Description, true);

            BaseOutput<Role> response = new()
            {
                IsSuccessful = roles.Any(),
                Response = roles?.FirstOrDefault() ?? new Role()
            };

            return response;
        }

        public async Task<BaseOutput<int>> Create(RoleDto roleDto)
        {
            BaseOutput<int> response = new();
            DateTime now = DateTime.UtcNow;

            ValidationUtil.ValidateClass(roleDto, _roleDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Role roleMapped = _mapper.Map<Role>(roleDto);

            roleMapped.CreateDate = now;
            roleMapped.AlterDate = now;

            await _roleRepository.AddAsync(roleMapped);
            await _unitOfWork.CommitAsync();

            response.Response = roleMapped.Id;

            return response;
        }

        public async Task<BaseOutput<Role>> Update(RoleDto roleDto)
        {
            BaseOutput<Role> response = new();

            ValidationUtil.ValidateClass(roleDto, _roleDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Role roleMapped = _mapper.Map<Role>(roleDto);
            roleMapped.AlterDate = DateTime.UtcNow;

            if (!await Verify(roleMapped.Id))
            {
                response.AddError("Not Found");
            }

            _roleRepository.Update(roleMapped);
            await _unitOfWork.CommitAsync();

            response.Response = roleMapped;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int Id)
        {
            BaseOutput<bool> response = new();

            Role role = new() { Id = Id };

            if (!await Verify(role.Id))
            {
                response.AddError("Not Found");
            }

            _roleRepository.Delete(role);
            await _unitOfWork.CommitAsync();

            response.Response = true;
            response.IsSuccessful = true;

            return response;
        }


        public async Task<bool> Verify(string description)
        {
            return await _roleRepository.ExistsAsync(x => x.Description == description);
        }
        public async Task<bool> Verify(int Id)
        {
            return await _roleRepository.ExistsAsync(x => x.Id == Id);
        }
    }
}
