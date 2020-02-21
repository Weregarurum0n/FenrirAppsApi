using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Login.Services
{
    public interface ILoginService
    {
        ApiResponse<UserDetail> GetUserDetails(AuthLogin req);
    }
}
