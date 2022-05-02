namespace CampanhaMeo.Atilio.Models
{
    public class QuestionStructFreeText : IQuestionStruct
    {

        protected readonly string value = "";
        public string? HelpText { get; set; }

        public string? Mask { get; set; }

        public int AnswerMaxLenght { get; set; }

        public IAnswerStruct GenerateEmptyAnswerStruct()
        {
            return new AnswerStructTextFree()
            {
                AnswerMaxLenght = AnswerMaxLenght,
                Mask = Mask,
                HelpText = HelpText
            };
        }

        public List<string> GetOptions()
        {
            return new List<string>() { value };
        }

    }
}