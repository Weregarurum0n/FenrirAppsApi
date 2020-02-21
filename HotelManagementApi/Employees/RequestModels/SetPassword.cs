namespace HotelManagementApi.Employees.RequestModels
{
    public class SetPassword
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
