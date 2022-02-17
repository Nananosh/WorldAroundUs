using System.Collections.Generic;

namespace WorldAroundUs.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ThemeViewModel Theme { get; set; }
        public int ThemeId { get; set; }
        public List<TestResultViewModel> TestResults { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}