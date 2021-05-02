using System;

namespace AnimeCharacterBirthdayApi.Ping
{
    public class PingAnimeCharacterBirthday : IPingAnimeCharacterBirthday
    {
        public string GetPingStatus()
        {
            return "ANIME CHARACTER BIRTHDAY:\n\nConnection Successfully executed on " + DateTime.Now + " (PST).";
        }
    }
}
