using ParkingAPILibrary.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ParkingAPILibrary.EntityMapping
{
    public class PriceMap
    {
        public PriceMap(EntityTypeBuilder<Price> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.PriceId);
            entityTypeBuilder.Property(x => x.PriceValue); //Perday value
            entityTypeBuilder.Property(x => x.PriceType).IsRequired();
        }
    }
}
