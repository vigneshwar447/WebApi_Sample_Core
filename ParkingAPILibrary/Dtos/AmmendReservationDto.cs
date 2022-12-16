namespace ParkingAPILibrary.Dtos
{
    public class AmmendReservationDto
    {
        public int ReservationId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PriceType { get; set; }
    }
}
