using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IValidator<UserRoleDto> _validator;

        public UserRoleController(IUserRoleService userRoleService,
                                  IValidator<UserRoleDto> validator)
        {
            _userRoleService = userRoleService;
            _validator = validator;
        }


        [HttpPost("AssignRoleUser")]
        public async Task<IActionResult> AssignRoleToUser(UserRoleDto userRoleDto)
        {
            try
            {
                ValidationResult validationResult = _validator.Validate(userRoleDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                //TODO: Usar UserService para validar a existência do Usuário
                //TODO: Usar RoleService para validar a existência da Role

                return Ok(await _userRoleService.AssignRoleToUser(userRoleDto));

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        [HttpPut("UnassignRoleUser")]
        public async Task<IActionResult> UnassignRoleToUser(UserRoleDto userRoleDto)
        {
            try
            {
                ValidationResult validationResult = _validator.Validate(userRoleDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                return Ok(await _userRoleService.UnassignRoleToUser(userRoleDto));

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        [HttpGet("GetRolesByUser")]
        public async Task<IActionResult> GetRolesByUser(int id)
        {
            try
            {
                return Ok(await _userRoleService.GetRolesByUser(id));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }
    }
}
