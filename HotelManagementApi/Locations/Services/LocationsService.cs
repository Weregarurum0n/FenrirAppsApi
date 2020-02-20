using HotelManagementApi.Locations.Repositories;
using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Locations.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _repository;

        public LocationsService(ILocationsRepository repository) => _repository = repository;

        public List<Country> GetCountries() => _repository.GetCountries();
        public ReturnStatus SetCountry(SetCountry req) => _repository.SetCountry(req);

        public List<State> GetStates(int countryId) => _repository.GetStates(countryId);
        public ReturnStatus SetState(SetState req) => _repository.SetState(req);

        public List<City> GetCities(int countryId, int stateId) => _repository.GetCities(countryId, stateId);
        public ReturnStatus SetCity(SetCity req) => _repository.SetCity(req);
    }
}
