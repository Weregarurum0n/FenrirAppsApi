using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Guests.Services
{
    public interface IGuestsService
    {
        List<Guest> GetGuests(GetGuests req);
        Guest GetGuest(int guestId);
        ReturnStatus SetGuest(SetGuest req);
    }
}
