using Figura.Speedway.Model.Parameters;
using Figura.Speedway.Service;
using Figura.SpeedwayRider.Model.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Figura.Speedway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeedwayController : Controller
    {
        private readonly ISpeedwayService _speedwayService;

        public SpeedwayController(ISpeedwayService spedwayService)
        {
            _speedwayService = spedwayService;
        }

        [HttpGet("AllRiders")]
        public async Task<List<Rider>> FetchAllRiders()
        {
            var res = await _speedwayService.GetAllRiders();

            return res;
        }

        [HttpPost("SpeedwayEvent")]
        public async Task<List<EventParameter>> SpeedwayEvent([FromBody] string uri)
        {
            var res = await _speedwayService.BuildSpeedwayEventBasedOnApiData(uri);
            return res;
        }

    }
}
