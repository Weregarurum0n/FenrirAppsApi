using System.Collections.Generic;
using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Permissions.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Permissions
{
    [Route("Permissions")]
    public class PermissionsController : Controller
    {
        private static IPermissionsService _service;

        public PermissionsController(IPermissionsService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Permission>> GetPermissions(GetPermissions req) => _service.GetPermissions(req);

        [HttpPost]
        public ReturnStatus SetPermission([FromBody] SetPermission req) => _service.SetPermission(req);
    }
}