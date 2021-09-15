namespace JapaneseLearningApi.Vocab.RequestModels
{
    public class SetVocab
    {
        public int VocabId { get; set; }
        public string Word { get; set; }
        public string Romaji { get; set; }
        public int Level { get; set; }
        public string Example1 { get; set; }
        public string Example2 { get; set; }
        public string Example3 { get; set; }
        public object Sound { get; set; }
        public bool Disabled { get; set; }
    }
}