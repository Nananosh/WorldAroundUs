using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs
{
    public interface ISectionService
    {
        Task<List<SubsectionViewModel>> GetSubsectionBySectionId(int id);
        Task<ThemeViewModel> GetThemeBySubsectionId(int id);
        Task<List<ThemeViewModel>> GetThemesBySubsectionId(int id);
        void RemoveSection(SectionViewModel model);
        void RemoveSubsection(SubsectionViewModel model);
        void RemoveTheme(ThemeViewModel model);
        SectionViewModel UpdateSection(SectionViewModel model);
        SubsectionViewModel UpdateSubsection(SubsectionViewModel model);
        ThemeViewModel UpdateTheme(ThemeViewModel model);
        SectionViewModel CreateSection(SectionViewModel model);
        SubsectionViewModel CreateSubsection(SubsectionViewModel model);
        ThemeViewModel CreateTheme(ThemeViewModel model);
        TestViewModel GetTestByThemeId(int id);
        List<QuestionAnswerOptionViewModel> GetFreeQuestionByTestId(int id, string userId);
        IEnumerable<SubsectionViewModel> GetAllSubsections();
        IEnumerable<ThemeViewModel> GetAllThemes();
        IEnumerable<AnswerOptionViewModel> GetAllAnswerOption();
        List<SectionViewModel> GetAllSections();
        List<TestResultViewModel> GetTestResultByTestId(int testId, string userId);
        TestResultViewModel GetResultTestByTestIdUserId(string userId, int testId);
        int MaxPointsInTest(int testId);
        void AddAnswerToQuestion(string userId, int answerId);
        List<ResponseHistoryViewModel> GetUserTestHistory(string userId, int testId);
        List<GlobalResult> GetRating();
        List<GlobalResult> GetRatingBySubsectionId(int subsectionId);
        List<UserSectionRecordViewModel> GetUserRecordsByAllSections(string userId);
    }
}