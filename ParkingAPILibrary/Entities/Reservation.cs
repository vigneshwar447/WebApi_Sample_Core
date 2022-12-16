namespace ParkingAPILibrary.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? VehicleNumber { get; set; }
        public int SlotId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double BookingPrice { get; set; }
        public bool IsVehiclePicked { get; set; }
        public bool IsCancelled { get; set; }
        public virtual ParkingSlot ParkingSlots { get; set; }
    }
}
