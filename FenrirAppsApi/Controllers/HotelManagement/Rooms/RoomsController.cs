using System.Collections.Generic;
using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Rooms.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement
{
    [Route("Rooms")]
    public class RoomsController : Controller
    {
        private static IRoomsService _service;

        public RoomsController() => _service = new RoomsService();

        [HttpGet]
        public List<Room> GetMany(GetRooms req) => _service.GetRooms(req);

        [HttpGet("{roomId}")]
        public Room GetSpecific(int roomId) => _service.GetRoom(roomId);

        [HttpPost]
        public ResponseStatus SetRoom([FromBody] SetRoom req) => _service.SetRoom(req);
    }
}