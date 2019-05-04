using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Repositories
{
    public class EmployeePermissionsRepository : IEmployeePermissionsRepository
    {
        public List<EmployeePermission> GetEmployeePermissions(int employeeId)
        {
            return null;
        }

        public ResponseStatus SetEmployeePermission(SetEmployeePermission req)
        {
            return null;
        }
    }
}
