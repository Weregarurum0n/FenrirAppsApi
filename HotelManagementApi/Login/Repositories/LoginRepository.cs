using HotelManagementApi.Employees.ResponseModels;
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

        public ApiResponse<UserDetail> GetUserDetails(AuthLogin req)
        {
            var result = null as UserDetail;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Login_Auth, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserName", req.UserName);
                cmd.Parameters.AddWithValue("@Password", req.Password);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;


                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new UserDetail();
                    while (dr.Read())
                    {
                        result.UserInfo = new Employee
                        {
                            EmployeeId = dr["EmployeeID"].ToSafeInt32(),
                            UserName = dr["UserName"].ToSafeString(),
                            FirstName = dr["FirstName"].ToSafeString(),
                            MidName = dr["MidName"].ToSafeString(),
                            LastName1 = dr["LastName1"].ToSafeString(),
                            LastName2 = dr["LastName2"].ToSafeString(),
                            Locked = dr["Locked"].ToSafeBool(),
                            LockedDateTime = dr["LockedDateTime"].ToSafeDateTime(),
                            RequiresReset = dr["RequiresReset"].ToSafeBool(),
                            EmployeeTypeId = dr["EmployeeTypeID"].ToSafeInt32(),
                            StartDateTime = dr["StartDateTime"].ToSafeDateTime(),
                            LastLoginDateTime = dr["LastLoginDateTime"].ToSafeDateTime(),
                            Terminated = dr["IncludeTerminated"].ToSafeBool(),
                            TerminatedDateTime = dr["TerminatedDateTime"].ToSafeDateTime(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        };
                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        result.UserPermissions.Add(new EmployeePermission
                        {
                            EmployeeId = dr["EmployeeID"].ToSafeInt32(),
                            PermissionId = dr["PermissionID"].ToSafeInt32(),
                            Name = dr["Name"].ToSafeString(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<UserDetail>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
    }
}
