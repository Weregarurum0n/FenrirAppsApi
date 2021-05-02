using Dapper;
using JapaneseLearningApi.Vocab.RequestModels;
using JapaneseLearningApi.Vocab.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Vocab.Repositories
{
    public class VocabRepository : IVocabRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Vocab_Get = "p_Vocab_Get";
        private static string p_Vocab_Set = "p_Vocab_Set";

        public VocabRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<VocabText>> GetAllVocab(GetVocab req)
        {
            return null;
        }

        public ApiResponse<VocabText> GetSpecificVocab(int id)
        {
            return null;
        }

        public ReturnStatus SetVocab(SetVocab req)
        {
            return null;
        }
    }
}
