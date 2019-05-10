using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Login.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnectionString _connectionString;

        private static string p_Countries_Get = "p_Countries_Get";

        public LoginRepository() => _connectionString = new ConnectionString();

        public UserDetail Login(AuthLogin req)
        {
            return new UserDetail();
        }
    }
}
