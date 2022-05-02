namespace CampanhaMeo.Atilio.Models
{
    public class AnswerGroupByInternetUserDTO
    {
        public AnswerGroupByInternetUserDTO()
        {

        }

        public AnswerGroupByInternetUserDTO(IGrouping<Guid, Answer> answerGroup)
        {
            InternetUserKey = answerGroup.Key;
            Answers = answerGroup.ToList();
        }

        public Guid InternetUserKey { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
