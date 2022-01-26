using AutoMapper;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SectionViewModel, Section>().ReverseMap();
            CreateMap<SubsectionViewModel, Subsection>().ReverseMap();
        }
    }
}