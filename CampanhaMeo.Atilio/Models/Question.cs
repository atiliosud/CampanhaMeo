using System.ComponentModel.DataAnnotations;
using CampanhaMeo.Atilio.ModelViews;
using Microsoft.AspNetCore.Identity;

namespace CampanhaMeo.Atilio.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }

        public List<Answer> Answers { get; set; }

        [Display(Name = "Pergunta")]
        [Required, MaxLength(200, ErrorMessage = "A pergunta não pode exceder 200 caracteres")]
        public string Title { get; set; }

        [Display(Name = "É obrigatório?")]
        [Required]
        public string IsMandatory { get; set; }

        [Display(Name = "Ordem")]
        [Required]
        public int Order { get; set; }

        [Display(Name = "Conteúdo")]

        public IQuestionStruct? Content { get; set; }

        [Display(Name = "Criado por")]
        [Required]
        public string CreateById { get; set; }

        [Display(Name = "Criado por")]
        public IdentityUser CreateBy { get; set; }

        [Display(Name = "Craiado às")]
        [Required]
        public DateTimeOffset CreateAt { get; set; }

        public QuestionGenericToAnswer GenerateEmptyAnswer()
        {
            var qg = new QuestionGenericToAnswer()
            {
                QuestionId = Id,
                Title = Title,
                IsMandatory = IsMandatory
            };

            if(this.Content is QuestionStructFreeText)
            {
                var c = this.Content as QuestionStructFreeText;
                qg.TypeQuestion = QuestionGenericToAnswer.TypeQuestionEnum.FreeText;
                qg.HelpText = c.HelpText;
                qg.Mask = c.Mask;
                qg.AnswerMaxLenght = c.AnswerMaxLenght;
            }else if (this.Content is QuestionStructMultiSelect)
            {
                var c = this.Content as QuestionStructMultiSelect;
                qg.TypeQuestion = QuestionGenericToAnswer.TypeQuestionEnum.MultiSelect;
                qg.HelpText = c.HelpText;
                qg.Options = c.Options;
                qg.AllowOthers = c.AllowOthers;
                qg.Selecteds = new bool[c.Options.Length];
            }
            else if (this.Content is QuestionStructSingleSelect)
            {
                var c = this.Content as QuestionStructSingleSelect;
                qg.TypeQuestion = QuestionGenericToAnswer.TypeQuestionEnum.SingleSelect;
                qg.HelpText = c.HelpText;
                qg.Options = c.Options;
                qg.AllowOthers = c.AllowOthers;
                qg.Selecteds = new bool[c.Options.Length];
            }

            return qg;
        }
    }
}
