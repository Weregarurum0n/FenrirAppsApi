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

        public PaymentsController() => _service = new PaymentsService();

        [HttpGet]
        public List<Payment> GetPayments(GetPayments req) => _service.GetPayments(req);

        [HttpGet("{paymentId}")]
        public Payment GetPayment(int paymentId) => _service.GetPayment(paymentId);

        [HttpPost]
        public ResponseStatus SetPayment([FromBody] SetPayment req) => _service.SetPayment(req);
    }
}