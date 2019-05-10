using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Permissions.Services
{
    public interface IPermissionsService
    {
        List<Permission> GetPermissions(GetPermissions req);
        Permission GetPermission(int permissionId);
        ReturnStatus SetPermission(SetPermission req);
    }
}
