using JapaneseLearningApi.Hiragana.RequestModels;
using JapaneseLearningApi.Hiragana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Hiragana.Repositories
{
    public class HiraganaRepository : IHiraganaRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Hiragana_Get = "p_Hiragana_Get";
        private static string p_Hiragana_Set = "p_Hiragana_Set";

        public HiraganaRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req)
        {
            var result = null as List<HiraganaText>;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Hiragana_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Character", req.Character);
                cmd.Parameters.AddWithValue("@Romaji", req.Romaji);
                cmd.Parameters.AddWithValue("@Level", req.Level);
                cmd.Parameters.AddWithValue("@IncludeDisabled", req.IncludeDisabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<HiraganaText>();
                    while (dr.Read())
                    {
                        result.Add(new HiraganaText
                        {
                            HiraganaId = dr["HiraganaID"].ToSafeInt32(),
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
                return new ApiResponse<List<HiraganaText>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ApiResponse<HiraganaText> GetSpecificHiragana(int id)
        {
            var result = null as HiraganaText;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Hiragana_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@HiraganaID", id);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new HiraganaText
                        {
                            HiraganaId = dr["HiraganaID"].ToSafeInt32(),
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
                return new ApiResponse<HiraganaText>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetHiragana(SetHiragana req)
        {
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Hiragana_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@HiraganaID", req.HiraganaId);
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
