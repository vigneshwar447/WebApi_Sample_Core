namespace ParkingAPILibrary.Dtos
{
    public class BookReservationDto
    {
        public int ReservationId { get; set; }
        public string? VehicleNumber { get; set; }
        public int SlotNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PriceType { get; set; }
    }
}
