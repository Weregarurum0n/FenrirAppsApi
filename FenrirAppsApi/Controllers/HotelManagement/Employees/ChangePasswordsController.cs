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

        public ChangePasswordsController() => _service = new ChangePasswordsService();

        [HttpPost]
        public ResponseStatus SetPassword([FromBody] SetPassword req) => _service.SetPassword(req);
    }
}
