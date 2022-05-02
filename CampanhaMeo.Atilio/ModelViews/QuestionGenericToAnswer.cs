using System.ComponentModel.DataAnnotations;
using CampanhaMeo.Atilio.Models;

namespace CampanhaMeo.Atilio.ModelViews
{
    public class QuestionGenericToAnswer
    {
        #region INPUT
        public Guid QuestionId { get; set; }

        [Display(Name = "Pergunta")]
        public string Title { get; set; }

        [Display(Name = "É obrigatório")]
        public string IsMandatory { get; set; }

        [Display(Name = "Tipo")]
        public TypeQuestionEnum TypeQuestion { get; set; }

        [Display(Name = "Texto de ajuda")]

        public string? HelpText { get; set; }

        [Display(Name = "Máscara")]
        public string? Mask { get; set; }

        [Display(Name = "Máximo de caracteres")]
        public int AnswerMaxLenght { get; set; }

        [Display(Name = "Opções")]
        public string[] Options { get; set; }

        [Display(Name = "Aceita 'outros'")]
        public bool AllowOthers { get; set; }
        #endregion

        #region OUTPUT
        [Display(Name = "Valor")]
        public string? Value { get; set; } = "";

        [Display(Name = "Selecionado")]
        public uint SelectedByIndex { get; set; }

        [Display(Name = "Selecionados")]
        public bool[] Selecteds { get; set; } = { };

        [Display(Name = "Selecionou outros")]
        public bool SelectedOthers { get; set; }

        [Display(Name = "Outros")]
        public string? OthersUserInput { get; set; } = "";

        #endregion

        public enum TypeQuestionEnum
        {
            FreeText = 1,
            MultiSelect = 2,
            SingleSelect = 3
        }

        public Answer ToModel()
        {
            Answer answer = new Answer();
            answer.QuestionId = QuestionId;
            if (TypeQuestion == TypeQuestionEnum.FreeText)
            {
                answer.QuestionAnswered = new AnswerStructTextFree()
                {
                    Value = Value,
                    AnswerMaxLenght = AnswerMaxLenght,
                    HelpText = HelpText,
                    Mask = Mask,
                };
            }else if (TypeQuestion == TypeQuestionEnum.MultiSelect)
            {
                answer.QuestionAnswered = new AnswerStructMultiSelect()
                {
                    HelpText = HelpText,
                    AllowOthers = AllowOthers,
                    Options = Options,
                    OthersUserInput = OthersUserInput,
                    SelectedOthers = SelectedOthers,
                    Selecteds = Selecteds
                };
            }else if(TypeQuestion == TypeQuestionEnum.SingleSelect)
            {
                answer.QuestionAnswered = new AnswerStructSingleSelect()
                {
                    HelpText = HelpText,
                    AllowOthers = AllowOthers,
                    Options = Options,
                    OthersUserInput = OthersUserInput,
                    SelectedByIndex = SelectedByIndex,
                    SelectedOthers = SelectedOthers,
                };
            }
            return answer;
        }
    }
}
