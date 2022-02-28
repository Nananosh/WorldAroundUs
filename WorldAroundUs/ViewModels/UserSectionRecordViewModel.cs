using System.Collections.Generic;
using WorldAroundUs.Models;

namespace WorldAroundUs.ViewModels
{
    public class UserSectionRecordViewModel
    {
        public string SectionName { get; set; }
        public int SectionId{ get; set; }
        public int CountTest { get; set; }
        public int CountTestSuccess { get; set; }
    }
}