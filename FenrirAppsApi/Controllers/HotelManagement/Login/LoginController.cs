using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Login.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace FenrirAppsApi.Controllers.HotelManagement.Login
{
    [Route("Login")]
    public class LoginController
    {
        private static ILoginService _service;

        public LoginController(ILoginService service) => _service = service;

        [HttpGet]
        public ApiResponse<UserDetail> GetUserDetails(AuthLogin req) => _service.GetUserDetails(req);
    }
}
