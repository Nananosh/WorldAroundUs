using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<QuestionAnswerOption> AnswerOption { get; set; }
    }
}