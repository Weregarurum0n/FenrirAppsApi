using HotelManagementApi.Guests.Repositories;
using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Guests.Services
{
    public class GuestsService : IGuestsService
    {
        private readonly IGuestsRepository _repository;

        public GuestsService(IGuestsRepository repository) => _repository = repository;

        public ApiResponse<List<Guest>> GetGuests(GetGuests req) => _repository.GetGuests(req);
        public ReturnStatus SetGuest(SetGuest req) => _repository.SetGuest(req);
    }
}
