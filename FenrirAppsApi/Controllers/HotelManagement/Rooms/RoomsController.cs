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
        public List<Room> GetRooms(GetRooms req) => _service.GetRooms(req);

        [HttpGet("{roomId}")]
        public Room GetRoom(int roomId) => _service.GetRoom(roomId);

        [HttpPost]
        public ReturnStatus SetRoom([FromBody] SetRoom req) => _service.SetRoom(req);
    }
}