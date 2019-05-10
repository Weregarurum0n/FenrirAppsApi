using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Employees.Repositories
{
    public interface IChangePasswordsRepository
    {
        ReturnStatus SetPassword(SetPassword req);
    }
}
