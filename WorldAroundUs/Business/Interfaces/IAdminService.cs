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
        IEnumerable<AnswerOptionViewModel> GetAllAnswerOptions();
        TestViewModel UpdateTest(TestViewModel model);
        QuestionViewModel UpdateQuestion(QuestionViewModel model);
        AnswerOptionViewModel UpdateAnswerOptions(AnswerOptionViewModel model);
        QuestionAnswerOptionViewModel UpdateQuestionAnswerOption(QuestionAnswerOptionViewModel model);
        void RemoveTest(TestViewModel model);
        void RemoveAnswerOption(AnswerOptionViewModel model);
        void RemoveQuestion(QuestionViewModel model);
        void RemoveQuestionAnswerOption(QuestionAnswerOptionViewModel model);
        TestViewModel CreateTest(TestViewModel modal);
        AnswerOptionViewModel CreateAnswerOption(AnswerOptionViewModel modal);
        QuestionViewModel CreateQuestion(QuestionViewModel modal);
        QuestionAnswerOptionViewModel CreateQuestionAnswerOption(QuestionAnswerOptionViewModel modal);
    }
}