using HotelManagementApi.Login.RequestModels;
using HotelManagementApi.Login.ResponseModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Login.Repositories
{
    public interface ILoginRepository
    {
        ApiResponse<UserDetail> GetUserDetails(AuthLogin req);
    }
}
