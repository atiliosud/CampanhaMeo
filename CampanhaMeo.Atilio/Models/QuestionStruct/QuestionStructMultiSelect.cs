namespace CampanhaMeo.Atilio.Models
{
    public class QuestionStructMultiSelect : IQuestionStruct
    {

        protected readonly string other = "Other";

        public string? HelpText { get; set; }
        public string[] Options { get; set; } = System.Array.Empty<string>();
        public bool AllowOthers { get; set; }
        public bool ShouldRandomizeOptions { get; set; } = false;

        public IAnswerStruct GenerateEmptyAnswerStruct()
        {
            return new AnswerStructMultiSelect()
            {
                HelpText = HelpText,
                Options = Options,
                AllowOthers = AllowOthers,
                ShouldRandomizeOptions = ShouldRandomizeOptions,
                Selecteds = new bool[Options.Length]
            };
        }

        public List<string> GetOptions()
        {
            var labels = Options.Select(x => x);
            if (AllowOthers)
            {
                labels = labels.Append(other);
            }
            return labels.ToList();
        }
    }
}