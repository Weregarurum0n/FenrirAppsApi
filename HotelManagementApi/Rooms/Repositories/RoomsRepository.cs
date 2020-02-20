using Dapper;
using HotelManagementApi.Rooms.RequestModels;
using HotelManagementApi.Rooms.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Rooms.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Rooms_Get = "p_Rooms_Get";
        private static string p_Rooms_Set = "p_Rooms_Set";

        public RoomsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public List<Room> GetRooms(GetRooms req)
        {
            var result = null as List<Room>;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Rooms_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@RoomID", req.RoomId);
                cmd.Parameters.AddWithValue("@RoomNo", req.RoomNo);
                cmd.Parameters.AddWithValue("@RoomTypeID", req.RoomTypeId);
                cmd.Parameters.AddWithValue("@RoomRate", req.RoomRate);
                cmd.Parameters.AddWithValue("@RoomStatusID", req.RoomStatusId);
                cmd.Parameters.AddWithValue("@MaxCapacity", req.MaxCapacity);
                cmd.Parameters.AddWithValue("@Disable", req.IncludeDisabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Room>();
                    while (dr.Read())
                    {
                        result.Add(new Room
                        {
                            RoomId = dr["RoomId"].ToSafeInt32(),
                            RoomNo = dr["RoomNo"].ToSafeInt32(),
                            RoomTypeId = dr["RoomTypeId"].ToSafeInt32(),
                            RoomRate = dr["RoomRate"].ToSafeDecimal(),
                            RoomStatusId = dr["RoomStatusId"].ToSafeInt32(),
                            MaxCapacity = dr["MaxCapacity"].ToSafeInt32(),
                            Disabled = dr["Disabled"].ToSafeBool(),
                        });
                    }
                }
            }
            return result;
        }

        public ReturnStatus SetRoom(SetRoom req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Rooms_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@RoomID", req.RoomId);
                cmd.Parameters.AddWithValue("@RoomNo", req.RoomNo);
                cmd.Parameters.AddWithValue("@RoomTypeID", req.RoomTypeId);
                cmd.Parameters.AddWithValue("@RoomRate", req.RoomRate);
                cmd.Parameters.AddWithValue("@RoomStatusID", req.RoomStatusId);
                cmd.Parameters.AddWithValue("@MaxCapacity", req.MaxCapacity);
                cmd.Parameters.AddWithValue("@Disable", req.Disable);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@lRetVal"].Value.ToSafeInt32(), cmd.Parameters["@sRetMsg"].Value.ToSafeString());
            }
        }
    }
}
