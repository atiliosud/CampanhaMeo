using CampanhaMeo.Atilio.Helpers;

namespace CampanhaMeo.Atilio.Models
{
    public class AnswerStructTextFree : QuestionStructFreeText, IAnswerStruct
    {
        public string Value { get; set; } = "";


        public IEnumerable<KeyValuePair<string, string>> ToDisplay()
        {
            return new KeyValuePair<string, string>[] { DictionaryExtensions.New(value, Value) };
        }
    }
}