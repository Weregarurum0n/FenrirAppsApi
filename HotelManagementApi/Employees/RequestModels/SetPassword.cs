﻿namespace HotelManagementApi.Employees.RequestModels
{
    public class SetPassword
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
