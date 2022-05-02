namespace CampanhaMeo.Atilio.Models
{
    public interface IAnswerStruct : IQuestionStruct
    {
        public IEnumerable<KeyValuePair<string, string>> ToDisplay();
    }
}