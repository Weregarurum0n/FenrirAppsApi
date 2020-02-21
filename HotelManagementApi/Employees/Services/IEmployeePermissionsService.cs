using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Services
{
    public interface IEmployeePermissionsService
    {
        ApiResponse<List<EmployeePermission>> GetEmployeePermissions(int employeeId);
        ReturnStatus SetEmployeePermission(SetEmployeePermission req);
    }
}
