namespace WorldAroundUs.Models
{
    public class ResponseHistory
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public QuestionAnswerOption Question { get; set; }
        public int QuestionId { get; set; }
    }
}