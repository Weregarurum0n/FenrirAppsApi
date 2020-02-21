using System.Collections.Generic;
using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Payments.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FenrirAppsApi.Controllers.HotelManagement
{
    [Route("Payments")]
    public class PaymentsController : Controller
    {
        private static IPaymentsService _service;

        public PaymentsController(IPaymentsService service) => _service = service;

        [HttpGet]
        public ApiResponse<List<Payment>> GetPayments(GetPayments req) => _service.GetPayments(req);

        [HttpPost]
        public ReturnStatus SetPayment([FromBody] SetPayment req) => _service.SetPayment(req);
    }
}