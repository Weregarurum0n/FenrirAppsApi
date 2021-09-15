using System.Collections.Generic;
using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Profile.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Vocab
{
    [Route("User")]
    public class Profile1Controller : Controller
    {
        private static IProfileService _service;

        public Profile1Controller(IProfileService service) => _service = service;

        [HttpGet("Login")]
        public ReturnStatus Login([FromBody] GetLogin req) => _service.Login(req);

        [HttpGet("Profile")]
        public ApiResponse<UserProfile> GetProfile() => _service.GetProfile();

        [HttpPost("ChangePassword")]
        public ReturnStatus ChangePassword([FromBody] SetPassword req) => _service.ChangePassword(req);

        [HttpGet("Theme")]
        public ApiResponse<AccentTheme> GetAccentTheme() => _service.GetAccentTheme();

        [HttpPost("Theme")]
        public ReturnStatus SetAccentTheme([FromBody] SetAccentTheme req) => _service.SetAccentTheme(req);
    }
}