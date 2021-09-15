namespace JapaneseLearningApi.Kanji.RequestModels
{
    public class SetKanji
    {
        public int KanjiId { get; set; }
        public string Character { get; set; }
        public string Romaji { get; set; }
        public int Level { get; set; }
        public string Example1 { get; set; }
        public string Example2 { get; set; }
        public string Example3 { get; set; }
        public object Sound { get; set; }
        public bool Disabled { get; set; }
    }
}