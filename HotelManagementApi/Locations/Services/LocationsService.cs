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

        public LocationsService() => _repository = new LocationsRepository();

        public List<Country> GetCountries() => _repository.GetCountries();
        public Country GetCountry(int countryId) => _repository.GetCountry(countryId);
        public ReturnStatus SetCountry(SetCountry req) => _repository.SetCountry(req);

        public List<State> GetStates(int countryId) => _repository.GetStates(countryId);
        public State GetState(int countryId, int stateId) => _repository.GetState(countryId, stateId);
        public ReturnStatus SetState(SetState req) => _repository.SetState(req);

        public List<City> GetCities(int countryId, int stateId) => _repository.GetCities(countryId, stateId);
        public City GetCity(int countryId, int stateId, int cityId) => _repository.GetCity(countryId, stateId, cityId);
        public ReturnStatus SetCity(SetCity req) => _repository.SetCity(req);
    }
}
