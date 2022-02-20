using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Subsection Subsection { get; set; }
        public int SubsectionId { get; set; }
        public List<TestResult> TestResults { get; set; }
        public List<Question> Questions { get; set; }
    }
}