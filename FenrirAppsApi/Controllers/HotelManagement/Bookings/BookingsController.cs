using System.Collections.Generic;
using System.IO;
using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Bookings.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Bookings
{
    //[Route(nameof(RouteHeader) + "Bookings")]
    [Route("Bookings")]
    public class BookingsController : Controller
    {
        private static IBookingsService _service;

        public BookingsController() => _service = new BookingsService();

        [HttpGet]
        public List<Booking> GetBookings(GetBookings req) => _service.GetBookings(req);

        [HttpGet("{bookingId}")]
        public Booking GetBooking(int bookingId) => _service.GetBooking(bookingId);

        [HttpPost]
        public ReturnStatus SetBooking([FromBody] SetBooking req) => _service.SetBooking(req);
    }
}