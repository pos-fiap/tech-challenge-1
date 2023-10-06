using AutoMapper;
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
        private readonly IValidator<LoginDto> _validator;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<LoginDto> validator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<User> GetUser(int Id)
        {
            return await _userRepository.GetAsync(Id);
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

        public async Task<BaseOutput<int>> RegisterUser(UserDto userDto)
        {
            var response = new BaseOutput<int>();

            var userMapped = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped.Id;
            response.IsSuccessful = true;

            return response;
        }

        public async Task<bool> VerifyUser(UserDto userDto)
        {
            return await _userRepository.ExistsAsync(x => x.Username == userDto.Username);
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
