using ParkingAPILibrary.IServices;
using ParkingAPILibrary.Dtos;
using ParkingAPILibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using ParkingAPILibrary.Entities;

namespace ParkingAPILibrary.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ReservationDbContext _reservationDbContext;

        public ParkingService(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        public List<GetAvailabilityDto> GetAvailability(DateTime fromDate, DateTime toDate, int PriceType)
        {
            var price = GetPriceDetails(fromDate, toDate, PriceType);

            var reservations = _reservationDbContext.Reservations.Include(r => r.ParkingSlots)
                     .Where(r =>
                             (r.FromDate.Date >= fromDate.Date && r.FromDate.Date <= toDate.Date) ||
                             (r.ToDate.Date >= fromDate.Date && r.ToDate.Date <= toDate.Date) ||
                             (fromDate.Date >= r.FromDate.Date && fromDate.Date <= r.ToDate.Date) ||
                             (toDate.Date >= r.FromDate.Date && toDate.Date <= r.ToDate.Date));

            var qry = reservations
                .GroupJoin(_reservationDbContext.ParkingSlots, R => R.SlotId, P => P.SlotNumber,
                (X, Y) => new { Reservation = X, Slots = Y })
                .SelectMany(X => X.Slots.DefaultIfEmpty(), (X, Y) => new { Reservation = X, Slots = Y });

            var bookedSlots = qry.Select(x => x.Slots).ToList();
            var availableSlots = _reservationDbContext.ParkingSlots.Where(c => !bookedSlots.Contains(c))
                .Select(x => new GetAvailabilityDto
                {
                    Amount = (float?)(price),
                    AvailabeSpaces = x.SlotId,
                }).ToList();
            return availableSlots;
        }

        public bool Book(BookReservationDto bookReservationDto)
        {
            var availability = GetAvailability(bookReservationDto.FromDate, bookReservationDto.ToDate, bookReservationDto.PriceType);
            var price = GetPriceDetails(bookReservationDto.FromDate, bookReservationDto.ToDate, bookReservationDto.PriceType);
            if (availability.Count >= 1)
            {
                var reservation = new Reservation
                {
                    VehicleNumber = bookReservationDto.VehicleNumber,
                    FromDate = bookReservationDto.FromDate,
                    ToDate = bookReservationDto.ToDate,
                    SlotId = availability.Select(r => r.SlotId).First(),
                    IsVehiclePicked = false,
                    IsCancelled = false,
                    BookingPrice = (float)(price),
                };
                _reservationDbContext.Reservations.Add(reservation);
                _reservationDbContext.SaveChanges();
            }
            return true;
        }

        public bool Cancel(CancelReservationDto cancelReservationDto)
        {
            var reservationDetails = _reservationDbContext.Reservations
                .Where(r => r.ReservationId == cancelReservationDto.ReservationId).Select(r => r).First();
            var result = false;
            if (reservationDetails != null)
            {
                reservationDetails.IsCancelled = true;
                _reservationDbContext.Update(reservationDetails);
                _reservationDbContext.SaveChanges();
                result= true;
            }
            return result;
        }

        public bool Amend(AmmendReservationDto ammendReservationDto)
        {            
            var reservationDetails = _reservationDbContext.Reservations
                .Where(r => r.ReservationId == ammendReservationDto.ReservationId).Select(r => r).First();

            var result = true;
            var availability = GetAvailability(reservationDetails.FromDate, ammendReservationDto.ToDate, ammendReservationDto.PriceType);
            if (availability.Count >= 1)
            {
                var price = GetPriceDetails(ammendReservationDto.FromDate, ammendReservationDto.ToDate, ammendReservationDto.PriceType);

                if (reservationDetails != null)
                {
                    reservationDetails.ToDate = ammendReservationDto.ToDate;
                    reservationDetails.BookingPrice = price;
                    _reservationDbContext.Update(reservationDetails);
                    _reservationDbContext.SaveChanges();
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public double GetPriceDetails(DateTime fromDate, DateTime toDate, int priceType)
        {
            System.TimeSpan diffResult = toDate.Subtract(fromDate);
            var days = Math.Ceiling(diffResult.TotalDays);
            if (days <= 0)
            {
                days = 1;
            }
            var price = _reservationDbContext.Prices.Where(r => r.PriceType == priceType).Select(t => t.PriceValue).FirstOrDefault();
            return price * days;
        }
    }
}
