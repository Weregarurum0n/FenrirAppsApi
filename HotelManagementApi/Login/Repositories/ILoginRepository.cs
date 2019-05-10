using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;

namespace HotelManagementApi.Login.Repositories
{
    public interface ILoginRepository
    {
        UserDetail Login(AuthLogin req);
    }
}
