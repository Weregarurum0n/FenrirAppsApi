using System.Collections.Generic;
using JapaneseLearningApi.Kanji.RequestModels;
using JapaneseLearningApi.Kanji.ResponseModels;
using JapaneseLearningApi.Kanji.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Kanji
{
    [Route("Kanji")]
    public class KanjiController : Controller
    {
        private static IKanjiService _service;

        public KanjiController(IKanjiService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<KanjiText>> GetAllKanji(GetKanji req) => _service.GetAllKanji(req);

        [HttpGet("{id}")]
        public ApiResponse<KanjiText> GetSpecificKanji(int id) => _service.GetSpecificKanji(id);

        [HttpPost]
        public ReturnStatus SetKanji([FromBody] SetKanji req) => _service.SetKanji(req);
    }
}
