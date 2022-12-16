using ParkingAPILibrary.Entities;
using ParkingAPILibrary.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPILibrary.Repositories
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext()
        { 
        }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<ParkingSlot> ParkingSlots { set; get; }
        public DbSet<Price> Prices { set; get; }
        public DbSet<PriceType> PriceType { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ReservationMap(modelBuilder.Entity<Reservation>());
            new ParkingSlotMap(modelBuilder.Entity<ParkingSlot>());
            new PriceMap(modelBuilder.Entity<Price>());
        }
    }
}
