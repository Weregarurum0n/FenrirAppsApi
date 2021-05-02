using System;

namespace HotelManagementApi.Shared
{
    public class HttpError
    {
        public string Error { get; set; }
        public Exception InnerError { get; set; }
    }
}
