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

        public RoomsController(IRoomsService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Room>> GetRooms(GetRooms req) => _service.GetRooms(req);

        [HttpPost]
        public ReturnStatus SetRoom([FromBody] SetRoom req) => _service.SetRoom(req);
    }
}