using JapaneseLearningApi.Kanji.RequestModels;
using JapaneseLearningApi.Kanji.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Kanji.Services
{
    public interface IKanjiService
    {
        ApiResponse<List<KanjiText>> GetAllKanji(GetKanji req);
        ApiResponse<KanjiText> GetSpecificKanji(int id);
        ReturnStatus SetKanji(SetKanji req);
    }
}
