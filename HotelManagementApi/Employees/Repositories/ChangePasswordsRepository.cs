using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Shared;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Employees.Repositories
{
    public class ChangePasswordsRepository : IChangePasswordsRepository //FIX
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_ChangePassword_Set = "p_ChangePassword_Set";

        public ChangePasswordsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ReturnStatus SetPassword(SetPassword req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_ChangePassword_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@UserName", req.UserName);
                
                cmd.Parameters.AddWithValue("@CurrentPassword", req.CurrentPassword);
                cmd.Parameters.AddWithValue("@NewPassword", req.NewPassword);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
