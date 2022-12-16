namespace ParkingAPILibrary.Entities
{
    public class ParkingSlot
    {
        public int SlotId { get; set; }
        public int SlotNumber { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
