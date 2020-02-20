using System.Collections.Generic;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Employees.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Employees
{
    [Route("EmployeePermissions")]
    public class EmployeePermissionsController
    {
        private static IEmployeePermissionsService _service;

        public EmployeePermissionsController(IEmployeePermissionsService service) => _service = service;

        [HttpGet("{employeeId}")]
        public List<EmployeePermission> GetEmployeePermissions(int employeeId) => _service.GetEmployeePermissions(employeeId);

        [HttpPost]
        public ReturnStatus SetEmployeePermission([FromBody] SetEmployeePermission req) => _service.SetEmployeePermission(req);
    }
}
