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

        public LocationsController(ILocationsService service) => _service = service;

        [HttpGet("Countries")]
        public ApiResponse<List<Country>> GetCountries() => _service.GetCountries();
        [HttpGet("Country")]
        public ReturnStatus SetCountry([FromBody] SetCountry req) => _service.SetCountry(req);

        [HttpGet("Country/{countryId}/States")]
        public ApiResponse<List<State>> GetStates(int countryId) => _service.GetStates(countryId);
        [HttpGet("Country/{countryId}/State")]
        public ReturnStatus SetState([FromBody] SetState req) => _service.SetState(req);

        [HttpGet("Country/{countryId}/State/{stateId}/Cities")]
        public ApiResponse<List<City>> GetCities(int countryId, int stateId) => _service.GetCities(countryId, stateId);
        [HttpPost]
        public ReturnStatus SetCity([FromBody] SetCity req) => _service.SetCity(req);
    }
}