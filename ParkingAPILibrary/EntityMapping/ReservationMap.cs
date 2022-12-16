using ParkingAPILibrary.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingAPILibrary.EntityMapping
{
    public class ReservationMap
    {
        public ReservationMap(EntityTypeBuilder<Reservation> entityTypeBuilder)
        { 
            entityTypeBuilder.HasKey(x=> x.ReservationId);
            entityTypeBuilder.Property(x=>x.SlotId);
            entityTypeBuilder.Property(x=>x.FromDate).IsRequired();
            entityTypeBuilder.Property(x => x.ToDate).IsRequired();
            entityTypeBuilder.Property(x => x.VehicleNumber).IsRequired();
            entityTypeBuilder.Property(x => x.BookingPrice).IsRequired();
            entityTypeBuilder.Property(x => x.IsVehiclePicked);
            entityTypeBuilder.Property(x => x.IsCancelled);
            entityTypeBuilder.HasOne(x => x.ParkingSlots).WithMany(r => r.Reservations).HasForeignKey(x => x.SlotId);
        }
    }
}
