using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Theme Theme { get; set; }
        public int ThemeId { get; set; }
        public List<TestResult> TestResults { get; set; }
        public List<Question> Questions { get; set; }
    }
}