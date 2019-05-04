using Dapper;
using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Rooms.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Rooms_Get = "p_Rooms_Get";
        private static string p_Rooms_Set = "p_Rooms_Set";

        public RoomsRepository() => _connectionString = new ConnectionString();

        public List<Room> GetRooms(GetRooms req)
        {
            return null;
        }

        public Room GetRoom(int roomId)
        {
            return null;
        }

        public ResponseStatus SetRoom(SetRoom req)
        {
            return null;
        }
    }
}
