using Dapper;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Employees.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Employees_Get = "p_Employees_Get";
        private static string p_Employees_Set = "p_Employees_Set";

        public EmployeesRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public List<Employee> GetEmployees(GetEmployees req)
        {
            var result = null as List<Employee>;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Employees_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@EmployeeID", req.EmployeeId);
                cmd.Parameters.AddWithValue("@UserName", req.UserName);
                cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                cmd.Parameters.AddWithValue("@MidName", req.MidName);
                cmd.Parameters.AddWithValue("@LastName1", req.LastName1);
                cmd.Parameters.AddWithValue("@LastName2", req.LastName2);
                cmd.Parameters.AddWithValue("@Locked", req.Locked);
                cmd.Parameters.AddWithValue("@LockedDateTime", req.LockedDateTime);
                cmd.Parameters.AddWithValue("@RequiresReset", req.RequiresReset);
                cmd.Parameters.AddWithValue("@EmployeeTypeID", req.EmployeeTypeId);
                cmd.Parameters.AddWithValue("@StartDateTime", req.StartDateTime);
                cmd.Parameters.AddWithValue("@LastLoginDateTime", req.LastLoginDateTime);
                cmd.Parameters.AddWithValue("@IncludeTerminated", req.IncludeTerminated);
                cmd.Parameters.AddWithValue("@TerminatedDateTime", req.TerminatedDateTime);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Employee>();
                    while (dr.Read())
                    {
                        result.Add(new Employee
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
                        });
                    }
                }
            }
            return result;
        }

        public ReturnStatus SetEmployee(SetEmployee req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Employees_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@EmployeeID", req.EmployeeId);
                cmd.Parameters.AddWithValue("@UserName", req.UserName);
                cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                cmd.Parameters.AddWithValue("@MidName", req.MidName);
                cmd.Parameters.AddWithValue("@LastName1", req.LastName1);
                cmd.Parameters.AddWithValue("@LastName2", req.LastName2);
                cmd.Parameters.AddWithValue("@Locked", req.Locked);
                cmd.Parameters.AddWithValue("@LockedDateTime", req.LockedDateTime);
                cmd.Parameters.AddWithValue("@RequiresReset", req.RequiresReset);
                cmd.Parameters.AddWithValue("@EmployeeTypeID", req.EmployeeTypeId);
                cmd.Parameters.AddWithValue("@StartDateTime", req.StartDateTime);
                cmd.Parameters.AddWithValue("@LastLoginDateTime", req.LastLoginDateTime);
                cmd.Parameters.AddWithValue("@IncludeTerminated", req.IncludeTerminated);
                cmd.Parameters.AddWithValue("@TerminatedDateTime", req.TerminatedDateTime);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@lRetVal"].Value.ToSafeInt32(), cmd.Parameters["@sRetMsg"].Value.ToSafeString());
            }
        }
    }
}
