using System;

namespace JapaneseLearningApi.Profile.ResponseModels
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public DateTime DateJoined { get; set; }
        public bool Gender { get; set; }
        public int SessionId { get; set; }
        public object ImageId { get; set; }
        public int ThemeId { get; set; }
        public int AccentId { get; set; }
    }
}