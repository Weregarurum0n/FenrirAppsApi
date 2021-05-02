﻿using JapaneseLearningApi.Katakana.RequestModels;
using JapaneseLearningApi.Katakana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Katakana.Services
{
    public interface IKatakanaService
    {
        ApiResponse<List<KatakanaText>> GetAllKatakana(GetKatakana req);
        ApiResponse<KatakanaText> GetSpecificKatakana(int id);
        ReturnStatus SetKatakana(SetKatakana req);
    }
}
