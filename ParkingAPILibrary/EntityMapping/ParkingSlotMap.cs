using ParkingAPILibrary.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ParkingAPILibrary.EntityMapping
{
    public class ParkingSlotMap
    {
        public ParkingSlotMap(EntityTypeBuilder<ParkingSlot> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SlotId);
            entityTypeBuilder.Property(x => x.SlotNumber);            
        }
    }
}
