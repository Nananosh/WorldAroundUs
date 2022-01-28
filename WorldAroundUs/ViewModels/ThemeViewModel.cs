namespace WorldAroundUs.ViewModels
{
    public class ThemeViewModel
    {
        public int Id { get; set; }
        public SubsectionViewModel Subsection { get; set; }
        public int SubsectionId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public string SoundUrl { get; set; }
    }
}