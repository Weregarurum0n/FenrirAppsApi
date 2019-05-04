using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Guests.Repositories
{
    public interface IGuestsRepository
    {
        List<Guest> GetGuests(GetGuests req);
        Guest GetGuest(int guestId);
        ResponseStatus SetGuest(SetGuest req);
    }
}
