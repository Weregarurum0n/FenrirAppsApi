using HotelManagementApi.Payments.Repositories;
using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Payments.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _repository;

        public PaymentsService(IPaymentsRepository repository) => _repository = repository;

        public List<Payment> GetPayments(GetPayments req) => _repository.GetPayments(req);
        public ReturnStatus SetPayment(SetPayment req) => _repository.SetPayment(req);
    }
}
