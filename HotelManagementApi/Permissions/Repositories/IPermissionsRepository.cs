using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Permissions.Repositories
{
    public interface IPermissionsRepository
    {
        List<Permission> GetPermissions(GetPermissions req);
        ReturnStatus SetPermission(SetPermission req);
    }
}
