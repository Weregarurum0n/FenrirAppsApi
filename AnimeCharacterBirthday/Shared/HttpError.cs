using System;

namespace AnimeCharacterBirthdayApi.Shared
{
    public class HttpError
    {
        public string Error { get; set; }
        public Exception InnerError { get; set; }
    }
}
