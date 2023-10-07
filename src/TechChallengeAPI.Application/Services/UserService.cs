using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginDto> _loginDtoValidator;
        private readonly IValidator<UserDto> _userDtoValidator;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> userDtoValidator, IValidator<LoginDto> loginDtoValidator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<BaseOutput<List<User>>> GetAllUsers()
        {
            BaseOutput<List<User>> response = new();

            IEnumerable<User> users = await _userRepository.GetAsync();

            response.IsSuccessful = true;
            response.Response = users.ToList();

            return response;
        }
        public async Task<BaseOutput<User>> GetUser(int Id)
        {
            User user = await _userRepository.GetAsync(Id);

            BaseOutput<User> response = new();

            response.IsSuccessful = true;
            response.Response = user;

            return response;
        }

        public async Task<BaseOutput<User>> GetUserByLogin(LoginDto loginDto)
        {
            var response = new BaseOutput<User>();

            var validationResult = _validator.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Username == loginDto.Username, true);

            response.Response = users.FirstOrDefault() ?? new User();
            return response;
        }

        public async Task<BaseOutput<User>> GetUserByLogin(LoginDto loginDto)
        {
            var response = new BaseOutput<User>();

            var validationResult = _validator.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Username == loginDto.Username, true);

            response.Response = users.FirstOrDefault() ?? new User();
            return response;
        }

        public async Task<BaseOutput<User>> GetUser(int Id)
        {
            User user = await _userRepository.GetAsync(Id);

            BaseOutput<User> response = new();

            response.IsSuccessful = true;
            response.Response = user;

            return response;
        }
        

        public async Task<BaseOutput<User>> GetUser(UserDto userDto)
        {
            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Username == userDto.Username, true);

            BaseOutput<User> response = new()
            {
                IsSuccessful = users.Any(),
                Response = users?.FirstOrDefault() ?? new User()
            };

            return response;
        }

        public async Task<BaseOutput<int>> RegisterUser(UserDto userDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(userDto, _userDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            User userMapped = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped.Id;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<BaseOutput<User>> UpdateUser(UserDto userDto)
        {
            BaseOutput<User> response = new();

            ValidationUtil.ValidateClass(userDto, _userDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            User userMapped = _mapper.Map<User>(userDto);

            if (!await VerifyUser(userMapped.Id))
            {
                response.IsSuccessful = false;
                response.AddError("Not Found");
            }

            _userRepository.Update(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<BaseOutput<bool>> DeleteUser(int Id)
        {
            BaseOutput<bool> response = new();

            User user = new() { Id = Id };

            if (!await VerifyUser(user.Id))
            {
                response.IsSuccessful = false;
                response.Response = false;
                response.AddError("Not Found");
            }

            _userRepository.Delete(user);
            await _unitOfWork.CommitAsync();

            response.Response = true;
            response.IsSuccessful = true;

            return response;
        }


        public async Task<bool> VerifyUser(string username)
        {
            return await _userRepository.ExistsAsync(x => x.Username == username);
        }
        public async Task<bool> VerifyUser(int Id)
        {
            return await _userRepository.ExistsAsync(x => x.Id == Id);
        }

        public async Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel)
        {
            user.RefreshToken = tokenModel.RefreshToken;
            user.RefreshTokenExpiryDate = tokenModel.ExpirationDate;
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _userRepository.GetSingleAsync(x => x.Username == username, true);
        }
    }
}
