namespace JapaneseLearningApi.Vocab.RequestModels
{
    public class GetVocab
    {
        public string Word { get; set; }
        public string Romaji { get; set; }
        public bool Disabled { get; set; }
    }
}
