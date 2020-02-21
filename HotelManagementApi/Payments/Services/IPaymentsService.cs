using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Payments.Services
{
    public interface IPaymentsService
    {
        ApiResponse<List<Payment>> GetPayments(GetPayments req);
        ReturnStatus SetPayment(SetPayment req);
    }
}
