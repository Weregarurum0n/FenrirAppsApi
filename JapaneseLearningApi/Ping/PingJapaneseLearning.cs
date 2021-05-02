using System;

namespace JapaneseLearningApi.Ping
{
    public class PingJapaneseLearning : IPingJapaneseLearning
    {
        public string GetPingStatus()
        {
            return "JAPANESE LEARNING:\n\nConnection Successfully executed on " + DateTime.Now + " (PST).";
        }
    }
}
