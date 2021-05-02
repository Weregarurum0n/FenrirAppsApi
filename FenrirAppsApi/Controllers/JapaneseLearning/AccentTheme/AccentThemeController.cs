using System.Collections.Generic;
using JapaneseLearningApi.AccentTheme.RequestModels;
using JapaneseLearningApi.AccentTheme.ResponseModels;
using JapaneseLearningApi.AccentTheme.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.AccentTheme
{
    [Route("AccentTheme")]
    public class HiraganaController : Controller
    {
        private static IAccentThemeService _service;

        public HiraganaController(IAccentThemeService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Accent>> GetAllThemes() => _service.GetAllThemes();

        [HttpGet("{AccentId}")]
        public ApiResponse<Accent> GetSpecificTheme(int id) => _service.GetSpecificTheme(id);

        [HttpPost]
        public ReturnStatus SetTheme([FromBody] SetAccent req) => _service.SetTheme(req);



        [HttpGet]
        public ApiResponse<List<Theme>> GetAllAccents() => _service.GetAllAccents();

        [HttpGet("{AccentId}")]
        public ApiResponse<Theme> GetSpecificAccents(int id) => _service.GetSpecificAccents(id);

        [HttpPost]
        public ReturnStatus SetTheme([FromBody] SetTheme req) => _service.SetTheme(req);
    }
}