using Dapper;
using JapaneseLearningApi.Hiragana.RequestModels;
using JapaneseLearningApi.Hiragana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Hiragana.Repositories
{
    public interface IHiraganaRepository
    {
        ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req);
        ApiResponse<HiraganaText> GetSpecificHiragana(int id);
        ReturnStatus SetHiragana(SetHiragana req);
    }
}
