using System;

namespace HotelManagementApi.Ping
{
    public class PingHotelManagement : IPingHotelManagement
    {
        public string GetPingStatus()
        {
            return "Connection Successfully executed on " + DateTime.Now + " (PST).";
        }
    }
}
