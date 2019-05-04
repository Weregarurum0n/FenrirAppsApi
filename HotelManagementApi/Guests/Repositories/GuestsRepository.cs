using Dapper;
using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Guests.Repositories
{
    public class GuestsRepository : IGuestsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Guests_Get = "p_Guests_Get";
        private static string p_Guests_Set = "p_Guests_Set";

        public GuestsRepository() => _connectionString = new ConnectionString();

        public List<Guest> GetGuests(GetGuests req)
        {
            return null;
        }

        public Guest GetGuest(int guestId)
        {
            return null;
        }

        public ResponseStatus SetGuest(SetGuest req)
        {
            return null;
        }
    }
}
