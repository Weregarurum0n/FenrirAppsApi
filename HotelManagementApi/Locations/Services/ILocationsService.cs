using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Locations.Services
{
    public interface ILocationsService
    {
        List<Country> GetCountries();
        Country GetCountry(int countryId);
        ResponseStatus SetCountry(SetCountry req);

        List<State> GetStates(int countryId);
        State GetState(int countryId, int stateId);
        ResponseStatus SetState(SetState req);
        
        List<City> GetCities(int countryId, int stateId);
        City GetCity(int countryId, int stateId, int cityId);
        ResponseStatus SetCity(SetCity req);
    }
}
