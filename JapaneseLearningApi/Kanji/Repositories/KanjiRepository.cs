using Dapper;
using JapaneseLearningApi.Kanji.RequestModels;
using JapaneseLearningApi.Kanji.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Kanji.Repositories
{
    public class KanjiRepository : IKanjiRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Kanji_Get = "p_Kanji_Get";
        private static string p_Kanji_Set = "p_Kanji_Set";

        public KanjiRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<KanjiText>> GetAllKanji(GetKanji req)
        {
            return null;
        }

        public ApiResponse<KanjiText> GetSpecificKanji(int id)
        {
            return null;
        }

        public ReturnStatus SetKanji(SetKanji req)
        {
            return null;
        }
    }
}
