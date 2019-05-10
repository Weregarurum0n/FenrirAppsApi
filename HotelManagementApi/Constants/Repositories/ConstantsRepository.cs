using Dapper;
using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementApi.Constants.Repositories
{
    public class ConstantsRepository : IConstantsRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Constants_Get = "p_Constants_Get";
        private static string p_Constants_Set = "p_Constants_Set";

        public ConstantsRepository() => _connectionString = new ConnectionString();

        public List<Constant> GetConstants(GetConstants req)
        {
            return null;
        }

        public Constant GetConstant(int constantId)
        {
            return null;
        }

        public ReturnStatus SetConstant(SetConstant req)
        {
            return null;
        }
    }
}