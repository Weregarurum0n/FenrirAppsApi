using System;

namespace HotelManagementApi.Ping
{
    public class PingHotelManagement : IPingHotelManagement
    {
        public string GetPingStatus()
        {
            return "HOTEL MANAGEMENT:\n\nConnection Successfully executed on " + DateTime.Now + " (PST).";
        }
    }
}
