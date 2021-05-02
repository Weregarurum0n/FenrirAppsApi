using Dapper;
using HotelManagementApi.Locations.RequestModels;
using HotelManagementApi.Locations.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Locations.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Countries_Get = "p_Countries_Get";
        private static string p_Countries_Set = "p_Countries_Set";

        private static string p_States_Get = "p_States_Get";
        private static string p_States_Set = "p_States_Set";

        private static string p_Cities_Get = "p_Cities_Get";
        private static string p_Cities_Set = "p_Cities_Set";

        public LocationsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<Country>> GetCountries()
        {
            var result = null as List<Country>;
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Countries_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CountryID", 0);
                cmd.Parameters.AddWithValue("@Name", string.Empty);
                cmd.Parameters.AddWithValue("@Abbrev", string.Empty);
                cmd.Parameters.AddWithValue("@IncludeDisabled", true);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Country>();
                    while (dr.Read())
                    {
                        result.Add(new Country
                        {
                            CountryId = dr["CountryID"].ToSafeInt32(),
                            Name = dr["Name"].ToSafeString(),
                            Abbrev = dr["Abbrev"].ToSafeString(),
                            Disabled = dr["Disabled"].ToSafeBool(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<List<Country>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
        public ReturnStatus SetCountry(SetCountry req)
        {
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Countries_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CountryID", req.CountryId);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Abbrev", req.Abbrev);
                cmd.Parameters.AddWithValue("@Disable", req.Disable);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }

        public ApiResponse<List<State>> GetStates(int countryId)
        {
            var result = null as List<State>;
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_States_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@StateID", 0);
                cmd.Parameters.AddWithValue("@CountryID", countryId);
                cmd.Parameters.AddWithValue("@Name", string.Empty);
                cmd.Parameters.AddWithValue("@Abbrev", string.Empty);
                cmd.Parameters.AddWithValue("@IncludeDisabled", true);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<State>();
                    while (dr.Read())
                    {
                        result.Add(new State
                        {
                            CountryId = dr["CountryID"].ToSafeInt32(),
                            Name = dr["Name"].ToSafeString(),
                            Abbrev = dr["Abbrev"].ToSafeString(),
                            Disabled = dr["Disabled"].ToSafeBool(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<List<State>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
        public ReturnStatus SetState(SetState req)
        {
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_States_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@StateID", req.StateId);
                cmd.Parameters.AddWithValue("@CountryID", req.CountryId);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Abbrev", req.Abbrev);
                cmd.Parameters.AddWithValue("@Disable", req.Disable);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }

        public ApiResponse<List<City>> GetCities(int countryId, int stateId)
        {
            var result = null as List<City>;
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Cities_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CityID", 0);
                cmd.Parameters.AddWithValue("@StateID", stateId);
                cmd.Parameters.AddWithValue("@CountryID", countryId);
                cmd.Parameters.AddWithValue("@Name", string.Empty);
                cmd.Parameters.AddWithValue("@Abbrev", string.Empty);
                cmd.Parameters.AddWithValue("@IncludeDisabled", true);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<City>();
                    while (dr.Read())
                    {
                        result.Add(new City
                        {
                            CountryId = dr["CountryID"].ToSafeInt32(),
                            Name = dr["Name"].ToSafeString(),
                            Abbrev = dr["Abbrev"].ToSafeString(),
                            Disabled = dr["Disabled"].ToSafeBool(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<List<City>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
        public ReturnStatus SetCity(SetCity req)
        {
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Cities_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CityID", req.CityId);
                cmd.Parameters.AddWithValue("@StateID", req.StateId);
                cmd.Parameters.AddWithValue("@CountryID", req.CountryId);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Abbrev", req.Abbrev);
                cmd.Parameters.AddWithValue("@Disable", req.Disable);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
