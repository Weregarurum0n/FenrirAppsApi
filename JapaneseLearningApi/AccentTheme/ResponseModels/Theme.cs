using System;

namespace JapaneseLearningApi.AccentTheme.ResponseModels
{
    public class Theme
    {
        public int UserId { get; set; }

        public int ThemeId { get; set; }
        public string Color { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}