﻿using Dapper;
using JapaneseLearningApi.Katakana.RequestModels;
using JapaneseLearningApi.Katakana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Katakana.Repositories
{
    public interface IKatakanaRepository
    {
        ApiResponse<List<KatakanaText>> GetAllKatakana(GetKatakana req);
        ApiResponse<KatakanaText> GetSpecificKatakana(int id);
        ReturnStatus SetKatakana(SetKatakana req);
    }
}
