using WorldAroundUs.Models;

namespace WorldAroundUs.ViewModels
{
    public class ResponseHistoryViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public QuestionAnswerOptionViewModel Question { get; set; }
        public int QuestionId { get; set; }
    }
}