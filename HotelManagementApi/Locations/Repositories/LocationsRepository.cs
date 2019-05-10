using Dapper;
using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Locations.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Countries_Get = "p_Countries_Get";
        private static string p_Countries_Set = "p_Countries_Set";

        private static string p_States_Get = "p_States_Get";
        private static string p_States_Set = "p_States_Set";

        private static string p_Cities_Get = "p_Cities_Get";
        private static string p_Cities_Set = "p_Cities_Set";

        public LocationsRepository() => _connectionString = new ConnectionString();

        public List<Country> GetCountries()
        {
            return null;
        }
        public Country GetCountry(int countryId)
        {
            return null;
        }
        public ReturnStatus SetCountry(SetCountry req)
        {
            return null;
        }

        public List<State> GetStates(int countryId)
        {
            return null;
        }
        public State GetState(int countryId, int stateId)
        {
            return null;
        }
        public ReturnStatus SetState(SetState req)
        {
            return null;
        }

        public List<City> GetCities(int countryId, int stateId)
        {
            return null;
        }
        public City GetCity(int countryId, int stateId, int cityId)
        {
            return null;
        }
        public ReturnStatus SetCity(SetCity req)
        {
            return null;
        }
    }
}
