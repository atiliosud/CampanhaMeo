using CampanhaMeo.Atilio.Helpers;

namespace CampanhaMeo.Atilio.Models
{
    public class AnswerStructMultiSelect : QuestionStructMultiSelect, IAnswerStruct
    {
        public bool[] Selecteds { get; set; } = { };

        public bool SelectedOthers { get; set; }

        public string OthersUserInput { get; set; } = "";

        public IEnumerable<KeyValuePair<string, string>> ToDisplay()
        {
            var output = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < Options.Length; i++)
            {
                output.Add(DictionaryExtensions.New(Options[i], Selecteds[i] ? "Sim" : "Não"));
            }

            if (SelectedOthers)
                output.Add(DictionaryExtensions.New(other, OthersUserInput));

            return output;
        }
    }
}