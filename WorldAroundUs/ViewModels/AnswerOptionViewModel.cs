using System.Collections.Generic;
using WorldAroundUs.Models;

namespace WorldAroundUs.ViewModels
{
    public class AnswerOptionViewModel
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? ImageUrl { get; set; }
        public List<QuestionAnswerOptionViewModel> Question { get; set; }
        public int QuestionId { get; set; }
    }
}