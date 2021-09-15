using JapaneseLearningApi.Hiragana.RequestModels;
using JapaneseLearningApi.Hiragana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Hiragana.Repositories
{
    public interface IHiraganaRepository
    {
        ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req);
        ApiResponse<HiraganaText> GetSpecificHiragana(int id);
        ReturnStatus SetHiragana(SetHiragana req);
    }
}
