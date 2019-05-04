using Dapper;
using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Permissions.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Permissions_Get = "p_Permissions_Get";
        private static string p_Permissions_Set = "p_Permissions_Set";

        public PermissionsRepository() => _connectionString = new ConnectionString();

        public List<Permission> GetPermissions(GetPermissions req)
        {
            return null;
        }

        public Permission GetPermission(int permissionId)
        {
            return null;
        }

        public ResponseStatus SetPermission(SetPermission req)
        {
            return null;
        }
    }
}
