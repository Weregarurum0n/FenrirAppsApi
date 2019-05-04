using System.Collections.Generic;
using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Guests.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement
{
    [Route("Guests")]
    public class GuestsController : Controller
    {
        private static IGuestsService _service;

        public GuestsController() => _service = new GuestsService();

        [HttpGet]
        public List<Guest> GetGuests(GetGuests req) => _service.GetGuests(req);

        [HttpGet("{guestId}")]
        public Guest GetGuest(int guestId) => _service.GetGuest(guestId);

        [HttpPost]
        public ResponseStatus SetGuest([FromBody] SetGuest req) => _service.SetGuest(req);
    }
}