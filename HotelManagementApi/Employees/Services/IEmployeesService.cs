using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Services
{
    public interface IEmployeesService
    {
        ApiResponse<List<Employee>> GetEmployees(GetEmployees req);
        ReturnStatus SetEmployee(SetEmployee req);
    }
}
