using ParkingAPILibrary.Entities;
using ParkingAPILibrary.Repositories;
using ParkingAPILibrary.IServices;

namespace ParkingAPILibrary.Services
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(ReservationDbContext context)
        {

            //Mock Data

            context.Reservations.Add(new Reservation() { ReservationId = 1, VehicleNumber = "AMG-5679", FromDate = DateTime.Now, ToDate = DateTime.Now.AddDays(4), SlotId = 1, BookingPrice = 200, IsCancelled = false, IsVehiclePicked = false }); ;
            context.Reservations.Add(new Reservation() { ReservationId = 2, VehicleNumber = "TPG-7895", FromDate = DateTime.Now, ToDate = DateTime.Now.AddDays(2), SlotId = 3, BookingPrice = 200, IsCancelled = false, IsVehiclePicked = false });

            context.PriceType.Add(new PriceType() { Id=1, Name ="Summer"});
            context.PriceType.Add(new PriceType() { Id=2, Name = "Winter" });
            
            context.Prices.Add(new Price() { PriceId = 1, PriceType = 1, PriceValue = 50 });
            context.Prices.Add(new Price() { PriceId = 2, PriceType = 2, PriceValue = 55 });
            


            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 1, SlotNumber = 0001 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 2, SlotNumber = 0002 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 3, SlotNumber = 0003 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 4, SlotNumber = 0004 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 5, SlotNumber = 0005 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 6, SlotNumber = 0006 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 7, SlotNumber = 0007 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 8, SlotNumber = 0008 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 9, SlotNumber = 0009 });
            context.ParkingSlots.Add(new ParkingSlot() { SlotId = 10, SlotNumber = 0010 });            

            context.SaveChanges();
        }
    }
}
