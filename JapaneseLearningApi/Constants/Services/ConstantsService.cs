using JapaneseLearningApi.Constants.Repositories;
using JapaneseLearningApi.Constants.RequestModels;
using JapaneseLearningApi.Constants.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Constants.Services
{
    public class ConstantsService : IConstantsService
    {
        private readonly IConstantsRepository _repository;

        public ConstantsService(IConstantsRepository repository) => _repository = repository;

        public ApiResponse<List<Constant>> GetConstants(GetConstants req) => _repository.GetConstants(req);
        public ReturnStatus SetConstant(SetConstant req) => _repository.SetConstant(req);
    }
}
