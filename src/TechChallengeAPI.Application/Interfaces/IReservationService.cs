﻿using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IReservationService
    {
        Task<BaseOutput<bool>> Delete(int id);
        Task<BaseOutput<IList<Reservation>>> Get();
        Task<BaseOutput<Reservation>> Get(int id);
        Task<BaseOutput<int>> Post(ReservationDto reservation);
        Task<BaseOutput<bool>> Update(ReservationDto reservation);
        Task<BaseOutput<bool>> CheckoutReservation(ReservationDto reservation);
    }
}