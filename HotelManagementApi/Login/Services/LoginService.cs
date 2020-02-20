using HotelManagementApi.Login.Repositories;
using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;

namespace HotelManagementApi.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository repository) => _repository = repository;

        public UserDetail Login(AuthLogin req)
        {
            return _repository.Login(req);
        }
    }
}
