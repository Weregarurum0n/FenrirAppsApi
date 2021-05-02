using System;

namespace JapaneseLearningApi.Shared
{
    public class HttpError
    {
        public string Error { get; set; }
        public Exception InnerError { get; set; }
    }
}
