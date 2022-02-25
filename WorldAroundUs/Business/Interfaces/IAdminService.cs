using System.Collections;
using System.Collections.Generic;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs.Business.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<TestViewModel> GetAllTests();
        IEnumerable<QuestionAnswerOptionViewModel> GetAllQuestionAnswerOptions();
        IEnumerable<QuestionViewModel> GetAllQuestions();
        TestViewModel UpdateTest(TestViewModel model);
        QuestionViewModel UpdateQuestion(QuestionViewModel model);
        QuestionAnswerOptionViewModel UpdateQuestionAnswerOption(QuestionAnswerOptionViewModel model);
        void RemoveTest(TestViewModel model);
        void RemoveQuestion(QuestionViewModel model);
        void RemoveQuestionAnswerOption(QuestionAnswerOptionViewModel model);
        TestViewModel CreateTest(TestViewModel modal);
        QuestionViewModel CreateQuestion(QuestionViewModel modal);
        QuestionAnswerOptionViewModel CreateQuestionAnswerOption(QuestionAnswerOptionViewModel modal);
    }
}