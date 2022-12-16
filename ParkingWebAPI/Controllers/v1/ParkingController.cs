using Microsoft.AspNetCore.Mvc;
using ParkingAPILibrary.Dtos;
using ParkingAPILibrary.IServices;

namespace ParkingAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet("GetAvailability")]
        public ActionResult GetAvailability([FromQuery] string fromDate, string toDate, int priceType)
        {            
            var data = _parkingService.GetAvailability(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate), priceType);
            return Ok(new
            {
                value = data.Count(),
            });
        }

        [HttpPost("BookSlot")]
        public ActionResult BookSlot(BookReservationDto bookReservationDto)
        {
            var data = _parkingService.Book(bookReservationDto);
            return Ok(data);
        }

        [HttpPost("Cancel")]
        public ActionResult Cancel(CancelReservationDto cancelReservationDto)
        {
            var data = _parkingService.Cancel(cancelReservationDto);
            return Ok(data);
        }

        [HttpPost("AmendReservation")]
        public ActionResult AmendReservation(AmmendReservationDto ammendReservationDto)
        {
            var data = _parkingService.Amend(ammendReservationDto);
            return Ok(data);
        }

        [HttpGet("GetPriceDetails")]
        public ActionResult PriceDetails([FromQuery] string fromDate, string toDate, int priceType)
        {
            var data = _parkingService.GetPriceDetails(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate), priceType);
            return Ok(data);
        }
    }
}
