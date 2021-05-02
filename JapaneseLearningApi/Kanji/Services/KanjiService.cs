using JapaneseLearningApi.Kanji.Repositories;
using JapaneseLearningApi.Kanji.RequestModels;
using JapaneseLearningApi.Kanji.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Kanji.Services
{
    public class KanjiService : IKanjiService
    {
        private readonly IKanjiRepository _repository;

        public KanjiService(IKanjiRepository repository) => _repository = repository;

        public ApiResponse<List<KanjiText>> GetAllKanji(GetKanji req) => _repository.GetAllKanji(req);
        public ApiResponse<KanjiText> GetSpecificKanji(int id) => _repository.GetSpecificKanji(id);
        public ReturnStatus SetKanji(SetKanji req) => _repository.SetKanji(req);
    }
}
