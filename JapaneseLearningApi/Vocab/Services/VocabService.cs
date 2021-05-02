using JapaneseLearningApi.Vocab.Repositories;
using JapaneseLearningApi.Vocab.RequestModels;
using JapaneseLearningApi.Vocab.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Vocab.Services
{
    public class VocabService : IVocabService
    {
        private readonly IVocabRepository _repository;

        public VocabService(IVocabRepository repository) => _repository = repository;

        public ApiResponse<List<VocabText>> GetAllVocab(GetVocab req) => _repository.GetAllVocab(req);
        public ApiResponse<VocabText> GetSpecificVocab(int id) => _repository.GetSpecificVocab(id);
        public ReturnStatus SetVocab(SetVocab req) => _repository.SetVocab(req);
    }
}
