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
        private readonly IValetRepository _valetRepository;
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IParkingSpotRepository _parkingSpotRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ReservationDto> _validator;

        public ReservationService(IReservationRepository reservationRepository,
                            IValetRepository valetRepository,
                            ICustomerVehicleRepository customerVehicleRepository,
                            IParkingSpotRepository parkingSpotRepository,
                            IValidator<ReservationDto> validator,
                            IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _validator = validator;
            _reservationRepository = reservationRepository;
            _valetRepository = valetRepository;
            _customerVehicleRepository = customerVehicleRepository;
            _parkingSpotRepository = parkingSpotRepository;
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

        public async Task<BaseOutput<IList<Reservation>>> Get()
        {
            return new BaseOutput<IList<Reservation>>((await _reservationRepository.GetAsync()).ToList());

        }

        public async Task<BaseOutput<Reservation>> Get(int id)
        {
            BaseOutput<Reservation> response = new()
            {
                Response = await _reservationRepository.GetAsync(id)
            };

            return response;
        }

        public async Task<BaseOutput<int>> Post(ReservationDto reservation)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(reservation, _validator, response);

            response = await ValidateReservationPost(response, reservation);

            if (response.Errors.Any())
            {
                return response;
            }

            var reservationMapped = _mapper.Map<Reservation>(reservation);
            reservationMapped.Entrance = DateTime.UtcNow;

            await _reservationRepository.AddAsync(reservationMapped);

            await _unitOfWork.CommitAsync();

            response.Response = reservation.Id;

            return response;
        }

        private async Task<BaseOutput<int>> ValidateReservationPost(BaseOutput<int> response, ReservationDto reservation)
        {
            var reservationsFound = await _reservationRepository.GetAsync(x => x.ParkingSpotId == reservation.ParkingSpotId, true);

            if (reservationsFound.Any())
            {
                response.AddError("Parking spot already occupied!");
            }

            var vehicleFoundOnSpot = await _reservationRepository.GetAsync(x => x.CustomerVehicleId == reservation.CustomerVehicleId && x.Finished == false, true);

            if (vehicleFoundOnSpot.Any())
            {
                response.AddError("Vehicle already in a Valet spot!");
            }

            var valet = await _valetRepository.GetSingleAsync(x => x.Id == reservation.ValetId, true);

            if (valet == null)
            {
                response.AddError("Valet do not exist!");
            }

            var parkingSpoty = await _parkingSpotRepository.GetSingleAsync(x => x.Id == reservation.ParkingSpotId, true);

            if (parkingSpoty == null)
            {
                response.AddError("Parking Spot do not exist!");
            }

            var customerVehicle = await _customerVehicleRepository.GetSingleAsync(x => x.Id == reservation.CustomerVehicleId, true);

            if (customerVehicle == null)
            {
                response.AddError("Customer Vehicle do not exist!");
            }

            if (valet != null && valet.CNHExpiration < DateTime.UtcNow.AddDays(30))
            {
                response.AddError("Valet document has expired!");
            }

            return response;
        }

        private async Task<BaseOutput<int>> ValidateReservationPut(BaseOutput<int> response, ReservationDto reservation)
        {
            var parkingSpoty = await _parkingSpotRepository.GetSingleAsync(x => x.Id == reservation.ParkingSpotId, true);

            if (parkingSpoty == null)
            {
                response.AddError("Parking Spot do not exist!");
            }

            var reservationsFound = await _reservationRepository.GetSingleAsync(x => x.ParkingSpotId == reservation.ParkingSpotId, true);

            if (reservationsFound != null && reservationsFound.CustomerVehicleId != reservation.CustomerVehicleId)
            {
                response.AddError("Parking spot already occupied!");
            }

            var valet = await _valetRepository.GetSingleAsync(x => x.Id == reservation.ValetId, true);

            if (valet == null)
            {
                response.AddError("Valet do not exist!");
            }

            var customerVehicle = await _customerVehicleRepository.GetSingleAsync(x => x.Id == reservation.CustomerVehicleId, true);

            if (customerVehicle == null)
            {
                response.AddError("Customer Vehicle do not exist!");
            }

            if (valet != null && valet.CNHExpiration < DateTime.UtcNow.AddDays(30))
            {
                response.AddError("Valet document has expired!");
            }

            return response;
        }

        public async Task<BaseOutput<int>> Update(ReservationDto reservation)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(reservation, _validator, response);

            response = await ValidateReservationPut(response, reservation);

            if (response.Errors.Any())
            {
                return response;
            }

            Reservation reservationMapped = _mapper.Map<Reservation>(reservation);

            _reservationRepository.Update(reservationMapped);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<BaseOutput<bool>> CheckoutReservation(int id)
        {
            BaseOutput<bool> response = new();

            var reservation = await _reservationRepository.GetSingleAsync(x => x.Id == id, true);

            reservation.Exit = DateTime.UtcNow;
            reservation.Finished = true;
            reservation.Paid = true;
            reservation.TimeParked = reservation.Exit.Value.Subtract(reservation.Entrance).Minutes;

            _reservationRepository.Update(reservation);

            await _unitOfWork.CommitAsync();

            return response;
        }
    }
}