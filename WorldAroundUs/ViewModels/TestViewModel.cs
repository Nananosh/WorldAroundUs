using System.Collections.Generic;
using WorldAroundUs.Models;

namespace WorldAroundUs.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Subsection Subsection { get; set; }
        public int SubsectionId { get; set; }
        public List<TestResultViewModel> TestResults { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}