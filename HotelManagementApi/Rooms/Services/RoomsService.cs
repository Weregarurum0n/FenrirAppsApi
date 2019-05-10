using HotelManagementApi.Rooms.Repositories;
using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Rooms.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly IRoomsRepository _repository;

        public RoomsService() => _repository = new RoomsRepository();

        public List<Room> GetRooms(GetRooms req) => _repository.GetRooms(req);
        public Room GetRoom(int roomId) => _repository.GetRoom(roomId);
        public ReturnStatus SetRoom(SetRoom req) => _repository.SetRoom(req);
    }
}
