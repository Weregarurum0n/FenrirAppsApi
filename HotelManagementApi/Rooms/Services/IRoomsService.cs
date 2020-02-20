using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Rooms.Services
{
    public interface IRoomsService
    {
        List<Room> GetRooms(GetRooms req);
        ReturnStatus SetRoom(SetRoom req);
    }
}
