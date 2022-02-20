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
            CreateMap<ThemeViewModel, Theme>().ReverseMap();
            CreateMap<AnswerOptionViewModel, AnswerOption>().ReverseMap();
            CreateMap<QuestionAnswerOptionViewModel, QuestionAnswerOption>().ReverseMap();
            CreateMap<ResponseHistoryViewModel, ResponseHistory>().ReverseMap();
            CreateMap<QuestionViewModel, Question>().ReverseMap();
            CreateMap<TestResultViewModel, TestResult>().ReverseMap();
            CreateMap<TestViewModel, Test>().ReverseMap();
        }
    }
}