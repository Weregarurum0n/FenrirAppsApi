using System;

namespace HotelManagementApi.Bookings.RequestModels
{
    public class GetBookings
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int PaymentId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int BookTypeId { get; set; }
        public decimal BookRate { get; set; }
        public string Comment { get; set; }
        public bool IncludeCanceled { get; set; }
        public DateTime CanceledDate { get; set; }
    }
}