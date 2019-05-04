using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Bookings.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Bookings_Get = "p_Bookings_Get";
        private static string p_Bookings_Set = "p_Bookings_Set";

        public BookingsRepository() => _connectionString = new ConnectionString();

        public List<Booking> GetBookings(GetBookings req)
        {
            return null;
        }

        public Booking GetBooking(int bookingId)
        {
            return null;
        }

        public ResponseStatus SetBooking(SetBooking req)
        {
            return null;
        }
    }
}