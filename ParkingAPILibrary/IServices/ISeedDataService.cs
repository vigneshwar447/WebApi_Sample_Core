using ParkingAPILibrary.Repositories;

namespace ParkingAPILibrary.IServices
{
    public interface ISeedDataService
    {
        void Initialize(ReservationDbContext dbContext);
    }
}
