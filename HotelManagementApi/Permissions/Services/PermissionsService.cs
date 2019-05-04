using HotelManagementApi.Permissions.Repositories;
using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Permissions.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IPermissionsRepository _repository;

        public PermissionsService() => _repository = new PermissionsRepository();

        public List<Permission> GetPermissions(GetPermissions req) => _repository.GetPermissions(req);
        public Permission GetPermission(int permissionId) => _repository.GetPermission(permissionId);
        public ResponseStatus SetPermission(SetPermission req) => _repository.SetPermission(req);
    }
}
