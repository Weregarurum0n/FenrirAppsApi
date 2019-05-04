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

        public ConstantsController() => _service = new ConstantsService();

        [HttpGet]
        public List<Constant> GetConstants(GetConstants req) => _service.GetConstants(req);

        [HttpGet("{constantId}")]
        public Constant GetConstant(int constantId) => _service.GetConstant(constantId);

        [HttpPost]
        public ResponseStatus SetConstant([FromBody] SetConstant req) => _service.SetConstant(req);
    }
}