using HotelManagementApi.Employees.ResponseModels;
using System.Collections.Generic;

namespace HotelManagementApi.Login.ResponseModels
{
    public class UserDetail
    {
        public Employee UserInfo { get; set; }
        public List<EmployeePermission> UserPermissions { get; set; }
    }
}
