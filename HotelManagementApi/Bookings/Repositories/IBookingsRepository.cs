using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Bookings.Repositories
{
    public interface IBookingsRepository
    {
        List<Booking> GetBookings(GetBookings req);
        Booking GetBooking(int bookingId);
        ResponseStatus SetBooking(SetBooking req);
    }
}
