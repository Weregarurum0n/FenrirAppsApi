using Dapper;
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
            return null;
        }

        public ApiResponse<KatakanaText> GetSpecificKatakana(int id)
        {
            return null;
        }

        public ReturnStatus SetKatakana(SetKatakana req)
        {
            return null;
        }
    }
}
