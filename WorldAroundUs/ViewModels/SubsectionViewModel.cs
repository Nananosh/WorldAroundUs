namespace WorldAroundUs.ViewModels
{
    public class SubsectionViewModel
    {
        public int Id { get; set; }
        public SectionViewModel Section { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public string Continent { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}