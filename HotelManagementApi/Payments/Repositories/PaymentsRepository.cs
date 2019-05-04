using Dapper;
using HotelManagementApi.Payments.RequestModels;
using HotelManagementApi.Payments.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Payments.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Payments_Get = "p_Payments_Get";
        private static string p_Payments_Set = "p_Payments_Set";

        public PaymentsRepository() => _connectionString = new ConnectionString();

        public List<Payment> GetPayments(GetPayments req)
        {
            return null;
        }

        public Payment GetPayment(int paymentId)
        {
            return null;
        }

        public ResponseStatus SetPayment(SetPayment req)
        {
            return null;
        }
    }
}
