namespace ParkingAPILibrary.Dtos
{
    public class GetAvailabilityDto
    {
        public int AvailabeSpaces { get; set; }
        public int SlotId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public float? Amount { get; set; }
    }
}
