using HotelManagementApi.Ping;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers
{
    [Route("Ping")]
    public class PingController : Controller
    {
        private static IPingHotelManagement _pingHotelManagement;

        public PingController()
        {
            _pingHotelManagement = new PingHotelManagement();
        }

        [HttpGet("HotelManagement")]
        public string Get(int id)
        {
            return _pingHotelManagement.GetPingStatus();
        }
    }
}
