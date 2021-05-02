using System;

namespace JapaneseLearningApi.Kanji.ResponseModels
{
    public class KanjiText
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

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}