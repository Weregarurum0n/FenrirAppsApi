using System;

namespace AnimeCharacterBirthdayApi.DataParse.ResponseModels
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string LoadUrl { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Birthday { get; set; }
    }
}