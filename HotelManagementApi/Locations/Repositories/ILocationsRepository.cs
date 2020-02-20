using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Locations.Repositories
{
    public interface ILocationsRepository
    {
        List<Country> GetCountries();
        ReturnStatus SetCountry(SetCountry req);

        List<State> GetStates(int countryId);
        ReturnStatus SetState(SetState req);

        List<City> GetCities(int countryId, int stateId);
        ReturnStatus SetCity(SetCity req);
    }
}
