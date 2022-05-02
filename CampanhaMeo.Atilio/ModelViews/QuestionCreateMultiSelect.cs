using System.ComponentModel.DataAnnotations;
using CampanhaMeo.Atilio.Models;

namespace CampanhaMeo.Atilio.ModelViews
{
    public class QuestionCreateMultiSelect
    {
        public QuestionCreateMultiSelect()
        {

        }
        public QuestionCreateMultiSelect(Guid surveyId, int numbOptions)
        {
            SurveyId = surveyId;
            if (numbOptions < 2)
            {
                numbOptions = 2;
            }
            Options = new string[numbOptions];
        }

        public Guid SurveyId { get; set; }




        [Display(Name = "Pergunta")]
        [Required, MaxLength(200, ErrorMessage = "A pergunta não pode exceder 200 caracteres")]
        public string Title { get; set; }

        [Display(Name = "Ordem")]
        [Required]
        public int Order { get; set; }

        [Display(Name = "Texto de ajuda")]
        public string? HelpText { get; set; }

        [Display(Name = "Opções")]
        public string[] Options { get; set; } = System.Array.Empty<string>();

        [Display(Name = "Aceita 'outros'")]
        public bool AllowOthers { get; set; }

        [Display(Name = "Embaralhar opções")]
        public bool ShouldRandomizeOptions { get; set; } = false;

        internal Question ToModel()
        {
            return new Question()
            {
                Id = new Guid(),
                SurveyId = SurveyId,
                Title = Title,
                Order = Order,
                IsMandatory = "sim",
                Content = new QuestionStructMultiSelect()
                {
                    Options = Options,
                    AllowOthers = AllowOthers,
                    ShouldRandomizeOptions = ShouldRandomizeOptions,
                    HelpText = HelpText
                }
            };
        }
    }
}
