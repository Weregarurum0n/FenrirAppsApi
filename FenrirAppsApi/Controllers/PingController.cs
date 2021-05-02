using AnimeCharacterBirthdayApi.Ping;
using HotelManagementApi.Ping;
using JapaneseLearningApi.Ping;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers
{
    [Route("Ping")]
    public class PingController : Controller
    {
        private static IPingHotelManagement _pingHotelManagement;
        private static IPingJapaneseLearning _pingJapaneseLearning;
        private static IPingAnimeCharacterBirthday _pingAnimeCharacterBirthday;

        public PingController()
        {
            _pingHotelManagement = new PingHotelManagement();
            _pingJapaneseLearning = new PingJapaneseLearning();
            _pingAnimeCharacterBirthday = new PingAnimeCharacterBirthday();
        }

        //public PingController(IPingHotelManagement pingHotelManagement, IPingJapaneseLearning pingJapaneseLearning, IPingAnimeCharacterBirthday pingAnimeCharacterBirthday)
        //{
        //    _pingHotelManagement = pingHotelManagement;
        //    _pingJapaneseLearning = pingJapaneseLearning;
        //    _pingAnimeCharacterBirthday = pingAnimeCharacterBirthday;
        //}

        [HttpGet("AnimeCharacterBirthday")]
        public string GetAnimeCHaracterBirthday()
        {
            return _pingAnimeCharacterBirthday.GetPingStatus();
        }

        [HttpGet("HotelManagement")]
        public string GetHotelManagement()
        {
            return _pingHotelManagement.GetPingStatus();
        }

        [HttpGet("JapaneseLearning")]
        public string GetJapaneseLearning()
        {
            return _pingJapaneseLearning.GetPingStatus();
        }
    }
}
