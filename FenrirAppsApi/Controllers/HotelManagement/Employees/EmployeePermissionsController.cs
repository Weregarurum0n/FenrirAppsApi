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

        public EmployeePermissionsController() => _service = new EmployeePermissionsService();

        [HttpGet("{employeeId}")]
        public List<EmployeePermission> GetEmployeePermissions(int employeeId) => _service.GetEmployeePermissions(employeeId);

        [HttpPost]
        public ResponseStatus SetEmployeePermission([FromBody] SetEmployeePermission req) => _service.SetEmployeePermission(req);
    }
}
