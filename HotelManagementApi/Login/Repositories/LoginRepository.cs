using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Shared;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Login.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Login_Auth = "p_Login_Auth";

        public LoginRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public UserDetail Login(AuthLogin req)
        {
            var result = null as UserDetail;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Login_Auth, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;


                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new UserDetail
                        {
                        };
                    }
                }
            }
            return result;
        }
    }
}
