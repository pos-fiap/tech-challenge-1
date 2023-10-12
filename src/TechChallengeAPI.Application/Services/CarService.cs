using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Interfaces
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CarDto> _validator;

        public CarService(ICarRepository carRepository,
                          IValidator<CarDto> validator,
                          IUnitOfWork unitOfWork,
                          IMapper mapper)
        {
            _validator = validator;
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Car? car = await _carRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (car is null)
            {
                response.AddError("Id de carro não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Car carMapped = _mapper.Map<Car>(car);

            _carRepository.Delete(carMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Car>>> GetCar()
        {
            return new BaseOutput<IList<Car>>((await _carRepository.GetAsync()).ToList());
        }

        public async Task<BaseOutput<Car>> GetCar(int id)
        {
            BaseOutput<Car> response = new()
            {
                Response = await _carRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(CarDto car)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(car, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Car carMapped = _mapper.Map<Car>(car);

            await _carRepository.AddAsync(carMapped);

            await _unitOfWork.CommitAsync();

            response.Response = car.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(CarDto car)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(car, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Car carMapped = _mapper.Map<Car>(car);

            _carRepository.Update(carMapped);

            await _unitOfWork.CommitAsync();

            return new BaseOutput<bool>();
        }
    }
}
