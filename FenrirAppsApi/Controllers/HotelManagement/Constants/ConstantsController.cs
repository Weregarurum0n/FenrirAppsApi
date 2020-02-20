using System.Collections.Generic;
using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Constants.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement.Constants
{
    [Route("Constants")]
    public class ConstantsController : Controller
    {
        private static IConstantsService _service;

        public ConstantsController(IConstantsService service) => _service = service;

        [HttpGet]
        public List<Constant> GetConstants(GetConstants req) => _service.GetConstants(req);

        [HttpPost]
        public ReturnStatus SetConstant([FromBody] SetConstant req) => _service.SetConstant(req);
    }
}