using System.Collections.Generic;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Employees.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Employees
{
    [Route("Employees")]
    public class EmployeesController : Controller
    {
        private static IEmployeesService _service;

        public EmployeesController() => _service = new EmployeesService();

        [HttpGet]
        public List<Employee> GetEmployees(GetEmployees req) => _service.GetEmployees(req);

        [HttpGet("{employeeId}")]
        public Employee GetEmployee(int employeeId) => _service.GetEmployee(employeeId);

        [HttpPost]
        public ResponseStatus SetEmployee([FromBody] SetEmployee req) => _service.SetEmployee(req);
    }
}