using System.Collections.Generic;

namespace WorldAroundUs.ViewModels
{
    public class QuestionAnswerOptionViewModel
    {
        public int Id { get; set; }
        public QuestionViewModel Question { get; set; }
        public int QuestionId { get; set; }
        public AnswerOptionViewModel AnswerOption { get; set; }
        public int AnswerOptionId { get; set; }
        public bool IsCorrectly { get; set; }
        public List<ResponseHistoryViewModel> ResponseHistories { get; set; }
    }
}