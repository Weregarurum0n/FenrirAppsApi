using Dapper;
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

        private static string p_Hiragana_Get = "p_Kanji_Get";
        private static string p_Hiragana_Set = "p_Kanji_Set";

        public HiraganaRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req)
        {
            return null;
        }

        public ApiResponse<HiraganaText> GetSpecificHiragana(int id)
        {
            return null;
        }

        public ReturnStatus SetHiragana(SetHiragana req)
        {
            return null;
        }
    }
}
