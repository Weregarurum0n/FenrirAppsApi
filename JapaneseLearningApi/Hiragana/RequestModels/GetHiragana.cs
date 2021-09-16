namespace JapaneseLearningApi.Hiragana.RequestModels
{
    public class GetHiragana
    {
        public string Character { get; set; }
        public string Romaji { get; set; }
        public int Level { get; set; }
        public bool IncludeDisabled { get; set; }
    }
}
