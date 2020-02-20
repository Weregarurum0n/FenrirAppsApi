using HotelManagementApi.Employees.Repositories;
using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Services
{
    public class EmployeePermissionsService : IEmployeePermissionsService
    {
        private readonly IEmployeePermissionsRepository _repository;

        public EmployeePermissionsService(IEmployeePermissionsRepository repository) => _repository = repository;

        public List<EmployeePermission> GetEmployeePermissions(int employeeId) => _repository.GetEmployeePermissions(employeeId);
        public ReturnStatus SetEmployeePermission(SetEmployeePermission req) => _repository.SetEmployeePermission(req);
    }
}
