using JapaneseLearningApi.Katakana.RequestModels;
using JapaneseLearningApi.Katakana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Katakana.Repositories
{
    public class KatakanaRepository : IKatakanaRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Katakana_Get = "p_Katakana_Get";
        private static string p_Katakana_Set = "p_Katakana_Set";

        public KatakanaRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<KatakanaText>> GetAllKatakana(GetKatakana req)
        {
            var result = null as List<KatakanaText>;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Katakana_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Character", req.Character);
                cmd.Parameters.AddWithValue("@Romaji", req.Romaji);
                cmd.Parameters.AddWithValue("@Level", req.Level);
                cmd.Parameters.AddWithValue("@Disabled", req.Disabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<KatakanaText>();
                    while (dr.Read())
                    {
                        result.Add(new KatakanaText
                        {
                            KatakanaId = dr["KatakanaID"].ToSafeInt32(),
                            Character = dr["Character"].ToSafeString(),
                            Romaji = dr["Romaji"].ToSafeString(),
                            Level = dr["Level"].ToSafeInt32(),
                            Example1 = dr["Example1"].ToSafeString(),
                            Example2 = dr["Example2"].ToSafeString(),
                            Example3 = dr["Example3"].ToSafeString(),
                            //Sound = dr["Sound"].ToSafeSoundPlayer(),
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
                return new ApiResponse<List<KatakanaText>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ApiResponse<KatakanaText> GetSpecificKatakana(int id)
        {
            var result = null as KatakanaText;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Katakana_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@KatakanaID", id);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new KatakanaText
                        {
                            KatakanaId = dr["KatakanaID"].ToSafeInt32(),
                            Character = dr["Character"].ToSafeString(),
                            Romaji = dr["Romaji"].ToSafeString(),
                            Level = dr["Level"].ToSafeInt32(),
                            Example1 = dr["Example1"].ToSafeString(),
                            Example2 = dr["Example2"].ToSafeString(),
                            Example3 = dr["Example3"].ToSafeString(),
                            //Sound = dr["Sound"].ToSafeSoundPlayer(),
                            Disabled = dr["Disabled"].ToSafeBool(),

                            CreatedId = dr["CreatedID"].ToSafeInt32(),
                            CreatedBy = dr["CreatedBy"].ToSafeString(),
                            CreatedDateTime = dr["CreatedDateTime"].ToSafeDateTime(),
                            ModifiedId = dr["ModifiedID"].ToSafeInt32(),
                            ModifiedBy = dr["ModifiedBy"].ToSafeString(),
                            ModifiedDateTime = dr["ModifiedDateTime"].ToSafeDateTime()
                        };
                    }
                }
                return new ApiResponse<KatakanaText>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetKatakana(SetKatakana req)
        {
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Katakana_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@KatakanaID", req.KatakanaId);
                cmd.Parameters.AddWithValue("@Character", req.Character);
                cmd.Parameters.AddWithValue("@Romaji", req.Romaji);
                cmd.Parameters.AddWithValue("@Level", req.Level);
                cmd.Parameters.AddWithValue("@Example1", req.Example1);
                cmd.Parameters.AddWithValue("@Example2", req.Example2);
                cmd.Parameters.AddWithValue("@Example3", req.Example3);
                cmd.Parameters.AddWithValue("@Sound", req.Sound);
                cmd.Parameters.AddWithValue("@Disabled", req.Disabled);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
