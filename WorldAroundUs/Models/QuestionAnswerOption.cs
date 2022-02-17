using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class QuestionAnswerOption
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public AnswerOption AnswerOption { get; set; }
        public int AnswerOptionId { get; set; }
        public bool IsCorrectly { get; set; }
        public List<ResponseHistory> ResponseHistories { get; set; }
    }
}