using JapaneseLearningApi.Vocab.RequestModels;
using JapaneseLearningApi.Vocab.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Vocab.Repositories
{
    public class VocabRepository : IVocabRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Vocab_Get = "p_Vocab_Get";
        private static string p_Vocab_Set = "p_Vocab_Set";

        public VocabRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<VocabText>> GetAllVocab(GetVocab req)
        {
            var result = null as List<VocabText>;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Vocab_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Word", req.Word);
                cmd.Parameters.AddWithValue("@Romaji", req.Romaji);
                cmd.Parameters.AddWithValue("@Level", req.Level);
                cmd.Parameters.AddWithValue("@IncludeDisabled", req.IncludeDisabled);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    result = new List<VocabText>();
                    while (dr.Read())
                    {
                        result.Add(new VocabText
                        {
                            VocabId = dr["VocabID"].ToSafeInt32(),
                            Word = dr["Word"].ToSafeString(),
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
                return new ApiResponse<List<VocabText>>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ApiResponse<VocabText> GetSpecificVocab(int id)
        {
            var result = null as VocabText;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Vocab_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@VocabID", id);

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new VocabText
                        {
                            VocabId = dr["VocabID"].ToSafeInt32(),
                            Word = dr["Word"].ToSafeString(),
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
                return new ApiResponse<VocabText>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }

        public ReturnStatus SetVocab(SetVocab req)
        {
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Vocab_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@VocabID", req.VocabId);
                cmd.Parameters.AddWithValue("@Word", req.Word);
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
