namespace HotelManagementApi.Employees.RequestModels
{
    public class SetEmployeePermission
    {
        public int? EmployeeId { get; set; }
        public int? PermissionId { get; set; }
        public bool Disable { get; set; }
    }
}