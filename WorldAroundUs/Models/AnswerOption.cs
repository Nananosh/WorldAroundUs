using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? ImageUrl { get; set; }
        public List<QuestionAnswerOption> Question { get; set; }
        public int QuestionId { get; set; }
    }
}