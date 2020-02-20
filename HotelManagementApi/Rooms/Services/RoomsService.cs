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

        public RoomsService(IRoomsRepository repository) => _repository = repository;

        public List<Room> GetRooms(GetRooms req) => _repository.GetRooms(req);
        public ReturnStatus SetRoom(SetRoom req) => _repository.SetRoom(req);
    }
}
