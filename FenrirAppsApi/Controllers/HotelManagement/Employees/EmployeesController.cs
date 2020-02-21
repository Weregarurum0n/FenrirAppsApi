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

        public EmployeesController(IEmployeesService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Employee>> GetEmployees(GetEmployees req) => _service.GetEmployees(req);

        [HttpPost]
        public ReturnStatus SetEmployee([FromBody] SetEmployee req) => _service.SetEmployee(req);
    }
}