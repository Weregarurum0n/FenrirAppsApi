using System;

namespace JapaneseLearningApi.Profile.ResponseModels
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public DateTime DateJoined { get; set; }
        public int Gender { get; set; }
        public string SessionId { get; set; }
        public int ThemeId { get; set; }
        public int AccentId { get; set; }
        public object ProfilePicture { get; set; }
        public object BannerImage { get; set; }
        public object Wallpaper { get; set; }
        public int HiraganaLevel { get; set; }
        public int KatakanaLevel { get; set; }
        public int KanjiLevel { get; set; }
        public int VocabLevel { get; set; }
    }
}