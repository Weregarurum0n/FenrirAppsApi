using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Login.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FenrirAppsApi.Controllers.HotelManagement.Login
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("Login")]
    public class KanjiController : Controller
    {
        private static ILoginService _service;

        public KanjiController(ILoginService service) => _service = service;

        [HttpGet("")]
        public ApiResponse<UserDetail> LoginGet([FromQuery] AuthLogin req)
        {
            return _service.GetUserDetails(req);
        }


        //private static ILoginService _service;

        //public LoginController(ILoginService service) => _service = service;

        //[HttpGet("")]
        //public ApiResponse<UserDetail> GetUserDetails(AuthLogin req) => _service.GetUserDetails(req);
    }
}
