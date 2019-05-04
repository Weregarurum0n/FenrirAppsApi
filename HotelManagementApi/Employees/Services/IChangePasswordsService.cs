using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Employees.Services
{
    public interface IChangePasswordsService
    {
        ResponseStatus SetPassword(SetPassword req);
    }
}
