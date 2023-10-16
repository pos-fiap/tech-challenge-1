using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Models;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginDto> _loginDtoValidator;
        private readonly IValidator<UserDto> _userDtoValidator;

        public UserService(IUserRepository userRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<UserDto> userDtoValidator,
                           IValidator<LoginDto> loginDtoValidator)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<BaseOutput<List<User>>> GetAllUsers()
        {
            BaseOutput<List<User>> response = new();

            IEnumerable<User> users = await _userRepository.GetAsync();

            response.Response = users.ToList();

            return response;
        }
        public async Task<BaseOutput<User>> GetUser(int Id)
        {
            User user = await _userRepository.GetAsync(Id);

            BaseOutput<User> response = new()
            {
                Response = user
            };

            return response;
        }

        public async Task<BaseOutput<User>> GetUser(LoginDto loginDto)
        {
            BaseOutput<User> response = new();

            var validationResult = _loginDtoValidator.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Username == loginDto.Username, true);

            response.Response = users.FirstOrDefault() ?? new User();
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

            IList<Person> person = _personRepository.GetPersonByDocument(userDto.PersonalInformations.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User userMapped = _mapper.Map<User>(userDto);

            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped.Id;

            return response;
        }

        public async Task<BaseOutput<User>> UpdateUser(UserDto userDto)
        {
            BaseOutput<User> response = new();

            ValidationUtil.ValidateClass(userDto, _userDtoValidator, response);

            //TODO: Criar verificação para a alteração de documento

            IList<Person> person = _personRepository.GetPersonByDocument(userDto.PersonalInformations.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            User userMapped = _mapper.Map<User>(userDto);

            if (!await VerifyUser(userMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _userRepository.Update(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped;

            return response;
        }

        public async Task<BaseOutput<bool>> DeleteUser(int Id)
        {
            BaseOutput<bool> response = new();

            User user = new() { Id = Id };

            if (!await VerifyUser(user.Id))
            {
                response.AddError("Not Found");
            }

            _userRepository.Delete(user);
            await _unitOfWork.CommitAsync();

            response.Response = true;

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

        public Task<User> GetUser(string username)
        {
            return _userRepository.GetSingleAsync(x => x.Username == username, true);
        }

    }
}
