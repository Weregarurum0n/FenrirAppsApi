using System.Collections.Generic;
using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Locations.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement
{
    [Route("Locations")]
    public class LocationsController : Controller
    {
        private static ILocationsService _service;

        public LocationsController() => _service = new LocationsService();

        [HttpGet("Countries")]
        public List<Country> GetCountries() => _service.GetCountries();
        [HttpGet("Country/{countryId}")]
        public Country GetCountry(int countryId) => _service.GetCountry(countryId);
        [HttpGet("Country")]
        public ReturnStatus SetCountry([FromBody] SetCountry req) => _service.SetCountry(req);

        [HttpGet("Country/{countryId}/States")]
        public List<State> GetStates(int countryId) => _service.GetStates(countryId);
        [HttpGet("Country/{countryId}/State/{stateId}")]
        public State GetState(int countryId, int stateId) => _service.GetState(countryId, stateId);
        [HttpGet("Country/{countryId}/State")]
        public ReturnStatus SetState([FromBody] SetState req) => _service.SetState(req);

        [HttpGet("Country/{countryId}/State/{stateId}/Cities")]
        public List<City> GetCities(int countryId, int stateId) => _service.GetCities(countryId, stateId);
        [HttpGet("Country/{countryId}/State/{stateId}/City/{cityId}")]
        public City GetCity(int countryId, int stateId, int cityId) => _service.GetCity(countryId, stateId, cityId);
        [HttpPost]
        public ReturnStatus SetCity([FromBody] SetCity req) => _service.SetCity(req);
    }
}