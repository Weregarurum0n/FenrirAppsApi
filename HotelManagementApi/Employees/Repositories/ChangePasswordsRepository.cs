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

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@UserName", req.UserId);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@lRetVal"].Value.ToSafeInt32(), cmd.Parameters["@sRetMsg"].Value.ToSafeString());
            }
        }
    }
}
