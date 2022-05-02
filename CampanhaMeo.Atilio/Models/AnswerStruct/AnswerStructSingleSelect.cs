using CampanhaMeo.Atilio.Helpers;

namespace CampanhaMeo.Atilio.Models
{
    public class AnswerStructSingleSelect : QuestionStructSingleSelect, IAnswerStruct
    {
        public uint SelectedByIndex { get; set; }

        public bool SelectedOthers { get; set; }

        public string OthersUserInput { get; set; } = "";

        public IEnumerable<KeyValuePair<string, string>> ToDisplay()
        {
            if (SelectedOthers || this.Options.Length < SelectedByIndex)
                return new KeyValuePair<string, string>[] { DictionaryExtensions.New(selected, OthersUserInput) };

            return new KeyValuePair<string, string>[] { DictionaryExtensions.New(selected, this.Options[SelectedByIndex]) };
        }
    }
}