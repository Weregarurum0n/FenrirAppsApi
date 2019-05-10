using HotelManagementApi.Bookings.Repositories;
using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Bookings.Services
{
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _repository;

        public BookingsService() => _repository = new BookingsRepository();

        public List<Booking> GetBookings(GetBookings req) => _repository.GetBookings(req);
        public Booking GetBooking(int bookingId) => _repository.GetBooking(bookingId);
        public ReturnStatus SetBooking(SetBooking req) => _repository.SetBooking(req);
    }
}
