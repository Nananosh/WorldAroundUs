using System.Collections.Generic;

namespace WorldAroundUs.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public Subsection Subsection { get; set; }
        public int SubsectionId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public string SoundUrl { get; set; }
        public List<Test> Tests { get; set; }
    }
}