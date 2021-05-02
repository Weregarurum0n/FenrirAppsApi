using System.Collections.Generic;
using AnimeCharacterBirthdayApi.DataParse.ResponseModels;
using AnimeCharacterBirthdayApi.DataParse.Services;
using AnimeCharacterBirthdayApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.AnimeCharacterBirthday.DataParse
{
    [Route("DataParse")]
    public class DataParseController : Controller
    {
        private static IDataParseService _service;

        public DataParseController() => _service = new DataParseService();

        [HttpGet]
        public ApiResponse<List<Character>> GetCharacterList() => _service.GetCharacterList();

        [HttpGet("Date/{date}/Month/{month}")]
        public ApiResponse<List<Character>> GetCharacterList(int date, string month) => _service.GetCharacterList(date, month);

        [HttpGet("{date}/{month}")]
        public string GetCharacterHTML(int date, Months month) => _service.GetCharacterHTML(date, month);
    }
}