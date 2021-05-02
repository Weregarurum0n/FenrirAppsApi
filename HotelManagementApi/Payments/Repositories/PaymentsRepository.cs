using Dapper;
using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Payments.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Payments_Get = "p_Payments_Get";
        private static string p_Payments_Set = "p_Payments_Set";

        public PaymentsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<Payment>> GetPayments(GetPayments req)
        {
            var result = null as List<Payment>;
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Payments_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PaymentID", req.PaymentId);
                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@Amount", req.Amount);
                cmd.Parameters.AddWithValue("@CardTypeID", req.CardTypeId);
                cmd.Parameters.AddWithValue("@SafetyDeposit", req.SafetyDeposit);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Payment>();
                    while (dr.Read())
                    {
                        result.Add(new Payment
                        {
                            PaymentId = dr["PaymentID"].ToSafeInt32(),
                            GuestId = dr["GuestID"].ToSafeInt32(),
                            Amount = dr["Amount"].ToSafeDecimal(),
                            CardTypeId = dr["CardTypeID"].ToSafeInt32(),
                            SafetyDeposit = dr["SafetyDeposit"].ToSafeDecimal(),
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
                return new ApiResponse<List<Payment>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetPayment(SetPayment req)
        {
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Payments_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PaymentID", req.PaymentId);
                cmd.Parameters.AddWithValue("@GuestID", req.GuestId);
                cmd.Parameters.AddWithValue("@Amount", req.Amount);
                cmd.Parameters.AddWithValue("@CardTypeID", req.CardTypeId);
                cmd.Parameters.AddWithValue("@SafetyDeposit", req.SafetyDeposit);
                cmd.Parameters.AddWithValue("@Comment", req.Comment);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
