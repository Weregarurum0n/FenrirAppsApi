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

        public BookingsService(IBookingsRepository repository) => _repository = repository;

        public List<Booking> GetBookings(GetBookings req) => _repository.GetBookings(req);
        public ReturnStatus SetBooking(SetBooking req) => _repository.SetBooking(req);
    }
}
