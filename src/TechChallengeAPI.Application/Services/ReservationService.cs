using AutoMapper;
using FluentValidation;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Utils;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ReservationDto> _validator;

        public ReservationService(IReservationRepository reservationRepository,
                            IValidator<ReservationDto> validator,
                            IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _validator = validator;
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Reservation reservation = await _reservationRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (reservation is null)
            {
                response.AddError("Vehicle not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Reservation reservationMapped = _mapper.Map<Reservation>(reservation);

            _reservationRepository.Delete(reservationMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<IList<Reservation>>> GetReservation()
        {
            return new BaseOutput<IList<Reservation>>((await _reservationRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<Reservation>> GetReservation(int id)
        {
            BaseOutput<Reservation> response = new()
            {
                Response = await _reservationRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Register(ReservationDto reservation)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(reservation, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            var reservationMapped = _mapper.Map<Reservation>(reservation);

            await _reservationRepository.AddAsync(reservationMapped);

            await _unitOfWork.CommitAsync();

            response.Response = reservation.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(ReservationDto reservation)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(reservation, _validator, response);

            if (response.Errors.Any())
            {
                return response;
            }

            Reservation reservationMapped = _mapper.Map<Reservation>(reservation);

            _reservationRepository.Update(reservationMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }
    }
}