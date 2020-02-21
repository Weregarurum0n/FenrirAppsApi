using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Locations.Services
{
    public interface ILocationsService
    {
        ApiResponse<List<Country>> GetCountries();
        ReturnStatus SetCountry(SetCountry req);

        ApiResponse<List<State>> GetStates(int countryId);
        ReturnStatus SetState(SetState req);

        ApiResponse<List<City>> GetCities(int countryId, int stateId);
        ReturnStatus SetCity(SetCity req);
    }
}
