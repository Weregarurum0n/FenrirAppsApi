using Dapper;
using JapaneseLearningApi.Kanji.RequestModels;
using JapaneseLearningApi.Kanji.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Kanji.Repositories
{
    public interface IKanjiRepository
    {
        ApiResponse<List<KanjiText>> GetAllKanji(GetKanji req);
        ApiResponse<KanjiText> GetSpecificKanji(int id);
        ReturnStatus SetKanji(SetKanji req);
    }
}
