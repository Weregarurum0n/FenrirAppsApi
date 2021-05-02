using System.Collections.Generic;
using JapaneseLearningApi.Katakana.RequestModels;
using JapaneseLearningApi.Katakana.ResponseModels;
using JapaneseLearningApi.Katakana.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Katakana
{
    [Route("Katakana")]
    public class KatakanaController : Controller
    {
        private static IKatakanaService _service;

        public KatakanaController(IKatakanaService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<KatakanaText>> GetAllKatakana(GetKatakana req) => _service.GetAllKatakana(req);

        [HttpGet("{id}")]
        public ApiResponse<KatakanaText> GetSpecificKatakana(int id) => _service.GetSpecificKatakana(id);

        [HttpPost]
        public ReturnStatus SetKatakana([FromBody] SetKatakana req) => _service.SetKatakana(req);
    }
}