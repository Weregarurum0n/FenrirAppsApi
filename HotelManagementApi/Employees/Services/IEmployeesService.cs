using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Services
{
    public interface IEmployeesService
    {
        List<Employee> GetEmployees(GetEmployees req);
        Employee GetEmployee(int employeeId);
        ReturnStatus SetEmployee(SetEmployee req);
    }
}
