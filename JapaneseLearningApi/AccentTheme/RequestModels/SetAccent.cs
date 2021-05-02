namespace JapaneseLearningApi.AccentTheme.RequestModels
{
    public class SetAccent
    {
        public int UserId { get; set; }

        public int AccentId { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public bool Disabled { get; set; }
    }
}