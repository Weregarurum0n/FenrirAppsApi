using System.Collections.Generic;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Employees.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Employees
{
    [Route("ChangePassword")]
    public class ChangePasswordsController
    {
        private static IChangePasswordsService _service;

        public ChangePasswordsController(IChangePasswordsService service) => _service = service;

        [HttpPost]
        public ReturnStatus SetPassword([FromBody] SetPassword req) => _service.SetPassword(req);
    }
}
