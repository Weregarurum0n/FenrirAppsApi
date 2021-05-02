using Dapper;
using JapaneseLearningApi.Vocab.RequestModels;
using JapaneseLearningApi.Vocab.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Vocab.Repositories
{
    public interface IVocabRepository
    {
        ApiResponse<List<VocabText>> GetAllVocab(GetVocab req);
        ApiResponse<VocabText> GetSpecificVocab(int id);
        ReturnStatus SetVocab(SetVocab req);
    }
}
