using ParkingAPILibrary.Repositories;
using ParkingAPILibrary.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ParkingAPILibrary.Helpers
{
    public static class SeedDataExtension
    {
        public static void SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ReservationDbContext>();
                var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();

                seedDataService.Initialize(dbContext);
            }
        }
    }
}
