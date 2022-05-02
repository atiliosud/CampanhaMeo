namespace CampanhaMeo.Atilio.Models
{
    public class QuestionStructSingleSelect : IQuestionStruct
    {
        protected readonly string selected = "";

        public bool IsReadOnly()
        {
            return false;
        }
        public List<string> GetOptions()
        {
            return new List<string>() { selected };
        }

        public string? HelpText { get; set; }
        public string[] Options { get; set; } = System.Array.Empty<string>();
        public bool AllowOthers { get; set; }
        public bool ShouldRandomizeOptions { get; set; } = false;
        public IAnswerStruct GenerateEmptyAnswerStruct()
        {
            return new AnswerStructSingleSelect()
            {
                HelpText = HelpText,
                Options = Options,
                AllowOthers = AllowOthers,
                ShouldRandomizeOptions = ShouldRandomizeOptions
            };
        }
    }
}