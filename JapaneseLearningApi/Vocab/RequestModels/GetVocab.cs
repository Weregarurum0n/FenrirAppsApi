namespace JapaneseLearningApi.Vocab.RequestModels
{
    public class GetVocab
    {
        public string Word { get; set; }
        public string Romaji { get; set; }
        public int Level { get; set; }
        public bool IncludeDisabled { get; set; }
    }
}
