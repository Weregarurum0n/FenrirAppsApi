using System.Collections.Generic;
using JapaneseLearningApi.Constants.RequestModels;
using JapaneseLearningApi.Constants.ResponseModels;
using JapaneseLearningApi.Constants.Services;
using JapaneseLearningApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.JapaneseLearning.Constants
{
    [Route("Constants")]
    public class ConstantsController : Controller
    {
        private static IConstantsService _service;

        public ConstantsController(IConstantsService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Constant>> GetConstants(GetConstants req) => _service.GetConstants(req);

        [HttpPost]
        public ReturnStatus SetConstant([FromBody] SetConstant req) => _service.SetConstant(req);
    }
}