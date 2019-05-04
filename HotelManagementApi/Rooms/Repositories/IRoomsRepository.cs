using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Rooms.Repositories
{
    public interface IRoomsRepository
    {
        List<Room> GetRooms(GetRooms req);
        Room GetRoom(int roomId);
        ResponseStatus SetRoom(SetRoom req);
    }
}
