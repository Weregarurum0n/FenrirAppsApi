using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Bookings.Repositories
{
    public interface IBookingsRepository
    {
        List<Booking> GetBookings(GetBookings req);
        ReturnStatus SetBooking(SetBooking req);
    }
}
