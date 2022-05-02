using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CampanhaMeo.Atilio.ModelViews;
using Microsoft.AspNetCore.Identity;

namespace CampanhaMeo.Atilio.Models
{

    public class Survey
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name ="Título")]
        [Required, MaxLength(200, ErrorMessage = "O título não pode exceder 200 caracteres")]
        public string Title { get; set; }

        [Display(Name = "Url amigável")]
        [Required, MaxLength(200, ErrorMessage = "A url amigável não pode exceder 200 caracteres")]
        [RegularExpression(@"^[a-zA-Z\-0-9]{1,200}$", ErrorMessage = "A url amigável deve conter apenas letras, números ou traço.")]
        public string FriendlyUrl { get; set; }


        [Display(Name = "Descrição")]
        [Required, MaxLength(5000, ErrorMessage = "A descrição não pode exceder 5000 caracteres")]
        public string Description { get; set; }


        [Display(Name = "Criado por")]
        [Required]
        public string CreateById { get; set; }

        [Display(Name = "Criado por")]
        public IdentityUser CreateBy { get; set; }

        [Display(Name = "Criado às")]
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset CreateAt { get; set; }

        [Display(Name = "Questões")]
        public List<Question> Questions { get; set; } = new List<Question>();


        private List<AnswerGroupByInternetUserDTO> _AnswerGroups { get; set; } = null;


        public List<AnswerGroupByInternetUserDTO> GetAnswerGroups()
        {
            if(_AnswerGroups == null)
            {
                _AnswerGroups = Questions
                    .SelectMany(x=>x.Answers)
                    .GroupBy(x=>x.InternetUserKey)
                    .Select(x=>new AnswerGroupByInternetUserDTO(x)).ToList();
            }
            return _AnswerGroups;
        }
        public List<QuestionGenericToAnswer> GenerateEmptyAnswers()
        {
            return Questions.Select(q =>
            {
                return q.GenerateEmptyAnswer();
            }).ToList();
        }
    }
}
