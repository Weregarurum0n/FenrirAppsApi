using Dapper;
using HotelManagementApi.Guests.RequestModels;
using HotelManagementApi.Guests.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Guests.Repositories
{
    public class GuestsRepository : IGuestsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Guests_Get = "p_Guests_Get";
        private static string p_Guests_Set = "p_Guests_Set";

        public GuestsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<Guest>> GetGuests(GetGuests req)
        {
            var result = null as List<Guest>;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Guests_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                cmd.Parameters.AddWithValue("@MidName", req.MidName);
                cmd.Parameters.AddWithValue("@LastName1", req.LastName1);
                cmd.Parameters.AddWithValue("@LastName2", req.LastName2);
                cmd.Parameters.AddWithValue("@GuestTypeID", req.GuestTypeId);
                cmd.Parameters.AddWithValue("@DLNo", req.DLNo);
                cmd.Parameters.AddWithValue("@BlackList", req.IncludeBlackListed);
                cmd.Parameters.AddWithValue("@BlackListDate", req.BlackListDate);
                cmd.Parameters.AddWithValue("@StreetAddress", req.StreetAddress);
                cmd.Parameters.AddWithValue("@CityID", req.CityId);
                cmd.Parameters.AddWithValue("@StateID", req.StateId);
                cmd.Parameters.AddWithValue("@CountryID", req.CountryId);
                cmd.Parameters.AddWithValue("@PostalCode", req.PostalCode);
                cmd.Parameters.AddWithValue("@Email", req.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", req.PhoneNumber);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Guest>();
                    while (dr.Read())
                    {
                        result.Add(new Guest
                        {
                            GuestId = dr["GuestID"].ToSafeInt32(),
                            FirstName = dr["FirstName"].ToSafeString(),
                            MidName = dr["MidName"].ToSafeString(),
                            LastName1 = dr["LastName1"].ToSafeString(),
                            LastName2 = dr["LastName2"].ToSafeString(),
                            GuestTypeId = dr["GuestTypeID"].ToSafeInt32(),
                            DLNo = dr["DLNo"].ToSafeString(),
                            BlackListed = dr["BlackListed"].ToSafeBool(),
                            BlackListDate = dr["BlackListDate"].ToSafeDateTime(),
                            StreetAddress = dr["StreetAddress"].ToSafeString(),
                            CityId = dr["CityId"].ToSafeInt32(),
                            StateId = dr["StateId"].ToSafeInt32(),
                            CountryId = dr["CountryId"].ToSafeInt32(),
                            PostalCode = dr["PostalCode"].ToSafeString(),
                            Email = dr["Email"].ToSafeString(),
                            PhoneNumber = dr["PhoneNumber"].ToSafeString(),
                            Comment = dr["Comment"].ToSafeString(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<List<Guest>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetGuest(SetGuest req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Guests_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                cmd.Parameters.AddWithValue("@MidName", req.MidName);
                cmd.Parameters.AddWithValue("@LastName1", req.LastName1);
                cmd.Parameters.AddWithValue("@LastName2", req.LastName2);
                cmd.Parameters.AddWithValue("@GuestTypeID", req.GuestTypeId);
                cmd.Parameters.AddWithValue("@DLNo", req.DLNo);
                cmd.Parameters.AddWithValue("@BlackList", req.BlackList);
                cmd.Parameters.AddWithValue("@BlackListDate", req.BlackListDate);
                cmd.Parameters.AddWithValue("@StreetAddress", req.StreetAddress);
                cmd.Parameters.AddWithValue("@CityID", req.CityId);
                cmd.Parameters.AddWithValue("@StateID", req.StateId);
                cmd.Parameters.AddWithValue("@CountryID", req.CountryId);
                cmd.Parameters.AddWithValue("@PostalCode", req.PostalCode);
                cmd.Parameters.AddWithValue("@Email", req.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", req.PhoneNumber);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
