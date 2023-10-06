using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDto userDto, [FromServices] IValidator<UserDto> validator)
        {
            try
            {
                ValidationResult validationResult = validator.Validate(userDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                var userExists = await _userService.VerifyUser(userDto);

                if (userExists)
                {
                    return BadRequestResponse("Erro ao cadastrar este e-mail!");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

                userDto.Password = passwordHash;

                BaseOutput<int> id = await _userService.RegisterUser(userDto);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }

        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseOutput<TokenDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var userResponse = await _userService.GetUserByLogin(loginDto);
                if (!userResponse.IsSuccessful)
                {
                    return CustomResponse(userResponse);
                }

                var validateResponse = _authService.ValidateLogin(userResponse.Response, loginDto);
                if(!validateResponse.IsSuccessful)
                {
                    return CustomResponse(validateResponse);
                }

                string token = _authService.GenerateJwtToken(userResponse.Response);
                var refreshToken = _authService.GenerateRefreshToken();

                await _userService.UpdateUserRefreshToken(userResponse.Response, refreshToken);

                var tokenDto = new TokenDto
                {
                    Token = token,
                    RefreshToken = refreshToken.RefreshToken
                };

                return Ok(new BaseOutput<TokenDto>(tokenDto));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshTokenAsync(TokenDto tokenDto)
        {
            try
            {
                var response = await _authService.RefreshExpiratedTokenAsync(tokenDto);
                if(!response.IsSuccessful)
                {
                    return CustomResponse(response);
                }

                return Ok(response.Response);
                
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


           
        }

    }
}
