﻿using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Payments.Services
{
    public interface IPaymentsService
    {
        List<Payment> GetPayments(GetPayments req);
        Payment GetPayment(int paymentId);
        ReturnStatus SetPayment(SetPayment req);
    }
}
