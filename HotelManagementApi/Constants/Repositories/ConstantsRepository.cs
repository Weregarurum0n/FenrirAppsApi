using Dapper;
using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementApi.Constants.Repositories
{
    public class ConstantsRepository : IConstantsRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Constants_Get = "p_Constants_Get";
        private static string p_Constants_Set = "p_Constants_Set";

        public ConstantsRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public List<Constant> GetConstants(GetConstants req)
        {
            var result = null as List<Constant>;
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Constants_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ConstantID", req.ConstantId);
                cmd.Parameters.AddWithValue("@ParentID", req.ParentId);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@Disable", req.IncludeDisabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<Constant>();
                    while (dr.Read())
                    {
                        result.Add(new Constant
                        {
                            ConstantId = dr["ConstantID"].ToSafeInt32(),
                            ParentId = dr["ParentID"].ToSafeInt32(),
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
            }
            return result;
        }

        public ReturnStatus SetConstant(SetConstant req)
        {
            using (var connection = new SqlConnection(_connectionString.Conn))
            {
                var cmd = new SqlCommand(p_Constants_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@lRetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sRetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ConstantID", req.ConstantId);
                cmd.Parameters.AddWithValue("@ParentID", req.ParentId);
                cmd.Parameters.AddWithValue("@Name", req.Name);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@Disable", req.IncludeDisabled);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@lRetVal"].Value.ToSafeInt32(), cmd.Parameters["@sRetMsg"].Value.ToSafeString());
            }
        }
    }
}