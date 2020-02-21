using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Guests.Services
{
    public interface IGuestsService
    {
        ApiResponse<List<Guest>> GetGuests(GetGuests req);
        ReturnStatus SetGuest(SetGuest req);
    }
}
