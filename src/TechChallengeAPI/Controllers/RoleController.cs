using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using TechChallenge.Api.Authorize;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Api.Controllers
{
    [CustomAuthorization]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _roleService.Get());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return CustomResponse(await _roleService.Get(Id));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RoleDto roleDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.Create(roleDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] RoleUpdateDto roleDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.Update(roleDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.Delete(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
