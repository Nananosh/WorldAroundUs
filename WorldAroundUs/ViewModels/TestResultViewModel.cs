using WorldAroundUs.Models;

namespace WorldAroundUs.ViewModels
{
    public class TestResultViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public TestViewModel Test { get; set; }
        public int TestId { get; set; }
        public int Points { get; set; }
    }
}