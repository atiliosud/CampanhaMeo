namespace CampanhaMeo.Atilio.Models
{
    public interface IQuestionStruct
    {
        List<string> GetOptions();

        IAnswerStruct GenerateEmptyAnswerStruct();
    }
}