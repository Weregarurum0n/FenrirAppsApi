using System.Collections.Generic;
using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Guests.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Guests
{
    [Route("Guests")]
    public class HiraganaController : Controller
    {
        private static IGuestsService _service;

        public HiraganaController(IGuestsService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Guest>> GetGuests(GetGuests req) => _service.GetGuests(req);

        [HttpPost]
        public ReturnStatus SetGuest([FromBody] SetGuest req) => _service.SetGuest(req);
    }
}