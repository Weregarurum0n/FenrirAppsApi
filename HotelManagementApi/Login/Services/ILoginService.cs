using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;

namespace HotelManagementApi.Login.Services
{
    public interface ILoginService
    {
        UserDetail Login(AuthLogin req);
    }
}
