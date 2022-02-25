using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorldAroundUs.Models
{
    public class Subsection
    {
        public int Id { get; set; }
        
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        [JsonIgnore]
        private List<Test> Tests { get; set; }
    }
}