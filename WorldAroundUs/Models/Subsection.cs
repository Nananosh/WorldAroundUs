namespace WorldAroundUs.Models
{
    public class Subsection
    {
        public int Id { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}