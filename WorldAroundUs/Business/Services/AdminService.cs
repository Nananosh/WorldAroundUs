using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldAroundUs.Business.Interfaces;
using WorldAroundUs.Migrations;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs.Services
{
    public class AdminService : IAdminService
    {
        private ApplicationContext db;
        private IMapper mapper;
        
        public AdminService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
        }
        
        public IEnumerable<TestViewModel> GetAllTests()
        {
            var tests = db.Tests
                .Include(x => x.Subsection);

            return mapper.Map<IEnumerable<TestViewModel>>(tests);
        }
        
        public IEnumerable<QuestionViewModel> GetAllQuestions()
        {
            var questions = db.Questions
                .Include(x => x.Test);

            return mapper.Map<IEnumerable<QuestionViewModel>>(questions);
        }

        public IEnumerable<AnswerOptionViewModel> GetAllAnswerOptions()
        {
            var answerOption = db.AnswerOptions;

            return mapper.Map<IEnumerable<AnswerOptionViewModel>>(answerOption);
        }

        public IEnumerable<QuestionAnswerOptionViewModel> GetAllQuestionAnswerOptions()
        {
            var questionAnswerOptions = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .Include(x => x.AnswerOption);

            return mapper.Map<IEnumerable<QuestionAnswerOptionViewModel>>(questionAnswerOptions);
        }
        
        public TestViewModel UpdateTest(TestViewModel model)
        {
            var test = db.Tests.FirstOrDefault(c => c.Id == model.Id);

            if (test != null)
            {
                test.Title = model.Title;
                test.SubsectionId = model.SubsectionId;

                db.SaveChanges();
            }

            var updatedTest = db.Tests.Include(x => x.Subsection).FirstOrDefault(c => c.Id == test.Id);

            return mapper.Map<TestViewModel>(updatedTest);
        }
        
        public QuestionViewModel UpdateQuestion(QuestionViewModel model)
        {
            var question = db.Questions.FirstOrDefault(c => c.Id == model.Id);

            if (question != null)
            {
                question.Text = model.Text;
                question.TestId = model.TestId;

                db.SaveChanges();
            }

            var updatedQuestion = db.Questions.Include(x =>x.Test).FirstOrDefault(c => c.Id == question.Id);

            return mapper.Map<QuestionViewModel>(updatedQuestion);
        }

        public AnswerOptionViewModel UpdateAnswerOptions(AnswerOptionViewModel model)
        {
            var answerOption = db.AnswerOptions.FirstOrDefault(x => x.Id == model.Id);

            if (answerOption != null)
            {
                answerOption.Text = model.Text;
                answerOption.ImageUrl = model.ImageUrl;
                db.SaveChanges();
            }

            var updatedAnswerOption = db.AnswerOptions.FirstOrDefault(x => x.Id == answerOption.Id);

            return mapper.Map<AnswerOptionViewModel>(updatedAnswerOption);
        }

        public QuestionAnswerOptionViewModel UpdateQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            var questionAnswer = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .Include(x => x.AnswerOption)
                .FirstOrDefault(c => c.Id == model.Id);

            if (questionAnswer != null)
            {
                questionAnswer.QuestionId = model.QuestionId;
                questionAnswer.AnswerOptionId = model.AnswerOptionId;
                questionAnswer.IsCorrectly = model.IsCorrectly;

                db.SaveChanges();
            }

            var updatedQuestionAnswerOption = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .Include(x => x.AnswerOption)
                .FirstOrDefault(c => c.Id == questionAnswer.Id);

            return mapper.Map<QuestionAnswerOptionViewModel>(updatedQuestionAnswerOption);
        }
        
        public void RemoveTest(TestViewModel model)
        {
            var removeTest = db.Tests
                .Include(u => u.Subsection)
                .FirstOrDefault(x => x.Id == model.Id);
            
            if (removeTest != null)
            {
                db.Tests.Remove(removeTest);
                db.SaveChanges();
            }
        }

        public void RemoveAnswerOption(AnswerOptionViewModel model)
        {
            var removeAnswerOption = db.AnswerOptions.FirstOrDefault(x => x.Id == model.Id);
            if (removeAnswerOption != null)
            {
                db.AnswerOptions.Remove(removeAnswerOption);
                db.SaveChanges();
            }
        }

        public void RemoveQuestion(QuestionViewModel model)
        {
            var removeQuestion = db.Questions
                .Include(u => u.Test)
                .FirstOrDefault(x => x.Id == model.Id);
            
            if (removeQuestion != null)
            {
                db.Questions.Remove(removeQuestion);
                db.SaveChanges();
            }
        }
        
        public void RemoveQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            var removeQuestionAnswerOption = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .Include(x => x.AnswerOption)
                .FirstOrDefault(x => x.Id == model.Id);
            
            if (removeQuestionAnswerOption != null)
            {
                db.QuestionAnswerOptions.Remove(removeQuestionAnswerOption);
                db.SaveChanges();
            }
        }

        public TestViewModel CreateTest(TestViewModel model)
        {
            var modelTest = mapper.Map<Test>(model);
            if (modelTest != null)
            {
                db.Tests.Add(modelTest);
                db.SaveChanges();
            }

            var addedTest = db.Tests
                .Include(x => x.Subsection)
                .FirstOrDefault(c => c.Id == modelTest.Id);

            return mapper.Map<TestViewModel>(addedTest);
        }

        public AnswerOptionViewModel CreateAnswerOption(AnswerOptionViewModel modal)
        {
            var modalAnswerOption = mapper.Map<AnswerOption>(modal);
            if (modalAnswerOption != null)
            {
                db.AnswerOptions.Add(modalAnswerOption);
                db.SaveChanges();
            }

            return mapper.Map<AnswerOptionViewModel>(modalAnswerOption);
        }

        public QuestionViewModel CreateQuestion(QuestionViewModel model)
        {
            var modelQuestion = mapper.Map<Question>(model);
            if (modelQuestion != null)
            {
                db.Questions.Add(modelQuestion);
                db.SaveChanges();
            }

            var addedQuestion = db.Questions.Include(x => x.Test).FirstOrDefault(c => c.Id == modelQuestion.Id);

            return mapper.Map<QuestionViewModel>(addedQuestion);
        }
        
        public QuestionAnswerOptionViewModel CreateQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            var modelQuestionAnswerOption = mapper.Map<QuestionAnswerOption>(model);
            if (modelQuestionAnswerOption != null)
            {
                db.QuestionAnswerOptions.Add(modelQuestionAnswerOption);
                db.SaveChanges();
            }

            var addedQuestion = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .Include(x => x.AnswerOption)
                .FirstOrDefault(c => c.Id == modelQuestionAnswerOption.Id);

            return mapper.Map<QuestionAnswerOptionViewModel>(addedQuestion);
        }
    }
}