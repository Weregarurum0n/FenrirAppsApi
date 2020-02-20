using Dapper;
using HotelManagementApi.Bookings.RequestModels;
using HotelManagementApi.Bookings.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Bookings.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Bookings_Get = "p_Bookings_Get";
        private static string p_Bookings_Set = "p_Bookings_Set";

        public BookingsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public List<Booking> GetBookings(GetBookings req)
        {
            var result = null as List<Booking>;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Bookings_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@BookingID", req.BookingId);
                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@PaymentID", req.PaymentId);
                cmd.Parameters.AddWithValue("@CheckInDate", req.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", req.CheckOutDate);
                cmd.Parameters.AddWithValue("@BookTypeID", req.BookTypeId);
                cmd.Parameters.AddWithValue("@BookRate", req.BookRate);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);
                cmd.Parameters.AddWithValue("@IncludeCanceled", req.IncludeCanceled);
                cmd.Parameters.AddWithValue("@CanceledDate", req.CanceledDate);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Booking>();
                    while (dr.Read())
                    {
                        result.Add(new Booking
                        {
                            BookingId = dr["BookingID"].ToSafeInt32(),
                            GuestId = dr["GuestID"].ToSafeInt32(),
                            PaymentId = dr["PaymentID"].ToSafeInt32(),
                            CheckInDate = dr["CheckInDate"].ToSafeDateTime(),
                            CheckOutDate = dr["CheckOutDate"].ToSafeDateTime(),
                            BookTypeId = dr["BookTypeID"].ToSafeInt32(),
                            BookRate = dr["BookRate"].ToSafeDecimal(),
                            Comment = dr["Comment"].ToSafeString(),
                            Canceled = dr["Canceled"].ToSafeBool(),
                            CanceledDate = dr["fTo"].ToSafeDateTime(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
            }
            return result;
        }

        public ReturnStatus SetBooking(SetBooking req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Bookings_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@BookingID", req.BookingId);
                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@PaymentID", req.PaymentId);
                cmd.Parameters.AddWithValue("@CheckInDate", req.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", req.CheckOutDate);
                cmd.Parameters.AddWithValue("@BookTypeID", req.BookTypeId);
                cmd.Parameters.AddWithValue("@BookRate", req.BookRate);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);
                cmd.Parameters.AddWithValue("@IncludeCanceled", req.IncludeCanceled);
                cmd.Parameters.AddWithValue("@CanceledDate", req.CanceledDate);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@lRetVal"].Value.ToSafeInt32(), cmd.Parameters["@sRetMsg"].Value.ToSafeString());
            }
        }
    }
}