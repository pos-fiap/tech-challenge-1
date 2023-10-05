using AutoMapper;
using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Domain.Interfaces;

namespace RCLocacoes.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> GetUser(int Id)
        {
            return await _userRepository.GetAsync(Id);
        }

        public async Task<User> GetUser(UserDto userDto)
        {
            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Username == userDto.Username, true);

            return users?.FirstOrDefault() ?? new User();
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
    }
}
