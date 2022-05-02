using System.ComponentModel.DataAnnotations;
using CampanhaMeo.Atilio.Models;
using Microsoft.AspNetCore.Identity;

namespace CampanhaMeo.Atilio.ModelViews
{
    public class QuestionCreateFreeText
    {
        public QuestionCreateFreeText()
        {
                    
        }
        public QuestionCreateFreeText(Guid v)
        {
            this.SurveyId = v;
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

        [Display(Name = "Máscara")]
        public string? Mask { get; set; }

        [Display(Name = "Máximo de caracteres")]
        public int AnswerMaxLenght { get; set; }

        internal Question ToModel()
        {
            return new Question()
            {
                Id = Guid.NewGuid(),
                SurveyId = SurveyId,
                Title = Title,
                Order = Order,
                IsMandatory = "sim",
                Content = new QuestionStructFreeText()
                {
                    AnswerMaxLenght = AnswerMaxLenght,
                    Mask = Mask,
                    HelpText = HelpText
                }
            };
        }
    }
}
