using HotelManagementApi.Employees.Repositories;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Shared;

namespace HotelManagementApi.Employees.Services
{
    public class ChangePasswordsService : IChangePasswordsService
    {
        private readonly IChangePasswordsRepository _repository;

        public ChangePasswordsService(IChangePasswordsRepository repository) => _repository = repository;

        public ReturnStatus SetPassword(SetPassword req) => _repository.SetPassword(req);
    }
}
