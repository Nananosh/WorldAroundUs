using System.Collections.Generic;

namespace WorldAroundUs.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TestViewModel Test { get; set; }
        public int TestId { get; set; }
        public int Point { get; set; }
        public List<QuestionAnswerOptionViewModel> AnswerOption { get; set; }
        public int AnswerOptionId { get; set; }
    }
}