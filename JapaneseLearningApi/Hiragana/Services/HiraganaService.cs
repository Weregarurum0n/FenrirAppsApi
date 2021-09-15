using JapaneseLearningApi.Hiragana.Repositories;
using JapaneseLearningApi.Hiragana.RequestModels;
using JapaneseLearningApi.Hiragana.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Hiragana.Services
{
    public class HiraganaService : IHiraganaService
    {
        private readonly IHiraganaRepository _repository;

        public HiraganaService(IHiraganaRepository repository) => _repository = repository;

        public ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req) => _repository.GetAllHiragana(req);
        public ApiResponse<HiraganaText> GetSpecificHiragana(int id) => _repository.GetSpecificHiragana(id);
        public ReturnStatus SetHiragana(SetHiragana req) => _repository.SetHiragana(req);
    }
}
