using System.Collections.Generic;
using JapaneseLearningApi.Vocab.RequestModels;
using JapaneseLearningApi.Vocab.ResponseModels;
using JapaneseLearningApi.Vocab.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Vocab
{
    [Route("Vocab")]
    public class ProfileController : Controller
    {
        private static IVocabService _service;

        public ProfileController(IVocabService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<VocabText>> GetAllVocab(GetVocab req) => _service.GetAllVocab(req);

        [HttpGet("{id}")]
        public ApiResponse<VocabText> GetSpecificVocab(int id) => _service.GetSpecificVocab(id);

        [HttpPost]
        public ReturnStatus SetVocab([FromBody] SetVocab req) => _service.SetVocab(req);
    }
}