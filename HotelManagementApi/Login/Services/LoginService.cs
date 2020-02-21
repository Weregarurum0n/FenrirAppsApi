using HotelManagementApi.Login.Repositories;
using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository repository) => _repository = repository;

        public ApiResponse<UserDetail> GetUserDetails(AuthLogin req)
        {
            return _repository.GetUserDetails(req);
        }
    }
}
