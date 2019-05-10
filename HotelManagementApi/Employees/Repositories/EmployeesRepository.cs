using Dapper;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Employees.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Employees_Get = "p_Employees_Get";
        private static string p_Employees_Set = "p_Employees_Set";

        private static string p_EmployeePermissions_Get = "p_EmployeePermissions_Get";
        private static string p_EmployeePermissions_Set = "p_EmployeePermissions_Set";

        public EmployeesRepository() => _connectionString = new ConnectionString();

        public List<Employee> GetEmployees(GetEmployees req)
        {
            var res = null as List<Employee>;
            var result = null as IEnumerable<Employee>;

            var resVal = 0;
            var resMsg = string.Empty;

            using (var conn = new SqlConnection(_connectionString.Conn))
            {
                conn.Open();

                result = conn.Query<Employee>("exec [dbo].[p_EmployeePermissions_Get] @lUserId, @lRetVal out, @sRetMsg out, " +
                    "@iEmployeeId",
                    new { UserId = 1, RetVal = resVal, RetMsg = resMsg,
                        EmployeeId = 1 });
            }

            return result.AsList();
        }

        public Employee GetEmployee(int employeeId)
        {
            return null;
        }

        public ReturnStatus SetEmployee(SetEmployee req)
        {
            return null;
        }
    }
}
