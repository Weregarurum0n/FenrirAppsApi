using JapaneseLearningApi.Constants.RequestModels;
using JapaneseLearningApi.Constants.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Constants.Repositories
{
    public interface IConstantsRepository
    {
        ApiResponse<List<Constant>> GetConstants(GetConstants req);
        ReturnStatus SetConstant(SetConstant req);
    }
}
