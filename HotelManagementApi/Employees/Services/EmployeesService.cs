using HotelManagementApi.Employees.Repositories;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _repository;

        public EmployeesService() => _repository = new EmployeesRepository();

        public List<Employee> GetEmployees(GetEmployees req) => _repository.GetEmployees(req);
        public Employee GetEmployee(int employeeId) => _repository.GetEmployee(employeeId);
        public ReturnStatus SetEmployee(SetEmployee req) => _repository.SetEmployee(req);
    }
}
