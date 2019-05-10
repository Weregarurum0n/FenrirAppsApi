using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Bookings.Services
{
    public interface IBookingsService
    {
        List<Booking> GetBookings(GetBookings req);
        Booking GetBooking(int bookingId);
        ReturnStatus SetBooking(SetBooking req);
    }
}
