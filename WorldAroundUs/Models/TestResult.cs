namespace WorldAroundUs.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public int Points { get; set; }
    }
}