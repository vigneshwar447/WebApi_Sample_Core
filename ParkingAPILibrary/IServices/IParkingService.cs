using ParkingAPILibrary.Dtos;

namespace ParkingAPILibrary.IServices
{
    public interface IParkingService
    {
        bool Amend(AmmendReservationDto ammendReservationDto);
        bool Book(BookReservationDto bookReservationDto);
        bool Cancel(CancelReservationDto cancelReservationDto);
        List<GetAvailabilityDto> GetAvailability(DateTime fromDate, DateTime toDate, int PriceType);
        double GetPriceDetails(DateTime fromDate, DateTime toDate, int priceType);
    }
}