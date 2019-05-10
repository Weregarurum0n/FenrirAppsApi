using System.Collections.Generic;
using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Permissions.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement
{
    [Route("Permissions")]
    public class PermissionsController : Controller
    {
        private static IPermissionsService _service;

        public PermissionsController() => _service = new PermissionsService();

        [HttpGet]
        public List<Permission> GetPermissions(GetPermissions req) => _service.GetPermissions(req);

        [HttpGet("{permissionId}")]
        public Permission GetPermission(int permissionId) => _service.GetPermission(permissionId);

        [HttpPost]
        public ReturnStatus SetPermission([FromBody] SetPermission req) => _service.SetPermission(req);
    }
}