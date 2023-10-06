﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Api.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("allRole")]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResponse(await _roleService.GetAllRoles());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet("verifyLisId")]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Role>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> VerifyListRole(List<int> Ids)
        {
            try
            {
                return (IActionResult)await _roleService.VerifyListRole(Ids);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost("AddRole")]        
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterRole([FromBody] RoleDto roleDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.RegisterRole(roleDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut("updateRole")]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Role>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteRole([FromBody] RoleDto roleDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.UpdateRole(roleDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete("deleteRole")]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteRole([FromQuery, NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _roleService.DeleteRole(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}