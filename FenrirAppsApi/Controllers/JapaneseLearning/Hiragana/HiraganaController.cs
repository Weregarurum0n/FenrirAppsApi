using System.Collections.Generic;
using JapaneseLearningApi.Hiragana.RequestModels;
using JapaneseLearningApi.Hiragana.ResponseModels;
using JapaneseLearningApi.Hiragana.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Hiragana
{
    [Route("Hiragana")]
    public class DataParseController : Controller
    {
        private static IHiraganaService _service;

        public DataParseController(IHiraganaService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<HiraganaText>> GetAllHiragana(GetHiragana req) => _service.GetAllHiragana(req);

        [HttpGet("{id}")]
        public ApiResponse<HiraganaText> GetSpecificHiragana(int id) => _service.GetSpecificHiragana(id);

        [HttpPost]
        public ReturnStatus SetHiragana([FromBody] SetHiragana req) => _service.SetHiragana(req);
    }
}