using System.ComponentModel.DataAnnotations;

namespace CampanhaMeo.Atilio.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        [Required]
        public Guid InternetUserKey { get; set; }

        public string Metadata { get; set; }
        public IAnswerStruct? QuestionAnswered { get; set; }

        [Required]
        public DateTimeOffset CreateAt { get; set; }
    }
}
