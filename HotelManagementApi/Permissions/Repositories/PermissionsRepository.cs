using Dapper;
using HotelManagementApi.Permissions.RequestModels;
using HotelManagementApi.Permissions.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Permissions.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Permissions_Get = "p_Permissions_Get";
        private static string p_Permissions_Set = "p_Permissions_Set";

        public PermissionsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<Permission>> GetPermissions(GetPermissions req)
        {
            var result = null as List<Permission>;
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Permissions_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PermissionID", req.PermissionId);
                cmd.Parameters.AddWithValue("@ParentID", req.ParentId);
                cmd.Parameters.AddWithValue("@Code", req.Code);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@IncludeDisabled", req.IncludeDisabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Permission>();
                    while (dr.Read())
                    {
                        result.Add(new Permission
                        {
                            PermissionId = dr["PermissionID"].ToSafeInt32(),
                            ParentId = dr["ParentID"].ToSafeInt32(),
                            Code = dr["Code"].ToSafeInt32(),
                            Name = dr["Name"].ToSafeString(),
                            Description = dr["Description"].ToSafeString(),
                            Disabled = dr["Disabled"].ToSafeBool(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        });
                    }
                }
                return new ApiResponse<List<Permission>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetPermission(SetPermission req)
        {
            using (var connection = new SqlConnection(_connectionString.HotelManagement))
            {
                var cmd = new SqlCommand(p_Permissions_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PermissionID", req.PermissionId);
                cmd.Parameters.AddWithValue("@ParentID", req.ParentId);
                cmd.Parameters.AddWithValue("@Code", req.Code);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@Disable", req.Disable);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
