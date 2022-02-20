using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorldAroundUs.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string BackgroundImage { get; set; }
        [JsonIgnore]
        public List<Subsection> Subsections { get; set; } 
    }
}