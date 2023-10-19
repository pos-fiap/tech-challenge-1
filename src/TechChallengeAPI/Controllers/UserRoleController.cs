using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Authorize;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [CustomAuthorization]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;
       
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        [HttpPost("AssignRoleUser")]
        public async Task<IActionResult> AssignRoleToUser(UserRoleDto userRoleDto)
        {
            try
            {

                //TODO: Usar UserService para validar a existência do Usuário
                //TODO: Usar RoleService para validar a existência da Role

                return ModelState.IsValid ? Ok(await _userRoleService.AssignRoleToUser(userRoleDto)) : CustomResponse(ModelState);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        [HttpGet("GetRolesByUser")]
        public async Task<IActionResult> GetRolesByUser(int userId)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _userRoleService.GetByUser(userId)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }
    }
}
