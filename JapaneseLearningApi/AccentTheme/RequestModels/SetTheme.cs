namespace JapaneseLearningApi.AccentTheme.RequestModels
{
    public class SetTheme
    {
        public int UserId { get; set; }

        public int ThemeId { get; set; }
        public string Color { get; set; }
        public bool Disabled { get; set; }
    }
}