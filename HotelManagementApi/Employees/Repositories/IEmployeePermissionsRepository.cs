using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Repositories
{
    public interface IEmployeePermissionsRepository
    {
        List<EmployeePermission> GetEmployeePermissions(int employeeId);
        ReturnStatus SetEmployeePermission(SetEmployeePermission req);
    }
}
