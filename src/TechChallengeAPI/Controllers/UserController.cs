using Microsoft.AspNetCore.Authorization;
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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _userService.Get());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        //[HttpPost("register"), Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Create(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]
        //[HttpDelete("delete"), Authorize]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UserUpdateDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Update(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        //[HttpDelete("delete"), Authorize]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Delete(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
