namespace JapaneseLearningApi.Profile.RequestModels
{
    public class SetPassword
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}