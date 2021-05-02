using JapaneseLearningApi.Katakana.Repositories;
using JapaneseLearningApi.Katakana.RequestModels;
using JapaneseLearningApi.Katakana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Katakana.Services
{
    public class KatakanaService : IKatakanaService
    {
        private readonly IKatakanaRepository _repository;

        public KatakanaService(IKatakanaRepository repository) => _repository = repository;

        public ApiResponse<List<KatakanaText>> GetAllKatakana(GetKatakana req) => _repository.GetAllKatakana(req);
        public ApiResponse<KatakanaText> GetSpecificKatakana(int id) => _repository.GetSpecificKatakana(id);
        public ReturnStatus SetKatakana(SetKatakana req) => _repository.SetKatakana(req);
    }
}
