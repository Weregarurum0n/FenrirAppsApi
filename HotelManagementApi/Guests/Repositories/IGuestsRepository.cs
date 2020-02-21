using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Guests.Repositories
{
    public interface IGuestsRepository
    {
        ApiResponse<List<Guest>> GetGuests(GetGuests req);
        ReturnStatus SetGuest(SetGuest req);
    }
}
