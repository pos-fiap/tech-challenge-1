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

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResponse(await _userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost("register")]
        //[HttpPost("register"), Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.RegisterUser(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut("update")]
        //[HttpDelete("delete"), Authorize]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser([FromBody] UserDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.UpdateUser(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete("delete")]
        //[HttpDelete("delete"), Authorize]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser([FromQuery, NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.DeleteUser(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
