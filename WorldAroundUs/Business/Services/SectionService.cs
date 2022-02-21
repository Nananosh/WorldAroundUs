using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldAroundUs.Migrations;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;


namespace WorldAroundUs.Services
{
    public class SectionService : ISectionService
    {
        private ApplicationContext db;
        private IMapper mapper;
        
        public SectionService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
        }
        
        public List<SectionViewModel>  GetAllSections()
        {
            var sections =  db.Sections.ToList();

            return mapper.Map<List<SectionViewModel>>(sections);
        }

        public async Task<List<SubsectionViewModel>> GetSubsectionBySectionId(int id)
        {
            var subsection =await db.Subsections.Include(x => x.Section).Where(s => s.SectionId == id).ToListAsync();

            return mapper.Map<List<SubsectionViewModel>>(subsection);
        }

        public void RemoveSection(SectionViewModel model)
        {
            var section = db.Sections.FirstOrDefault(s => s.Id == model.Id);

            if (section == null) return;
            
            db.Sections.Remove(section);
            db.SaveChanges();
        }
        
        public void RemoveSubsection(SubsectionViewModel model)
        {
            var subsection = db.Subsections.FirstOrDefault(s => s.Id == model.Id);

            if (subsection == null) return;
            
            db.Subsections.Remove(subsection);
            db.SaveChanges();
        }
        
        public void RemoveTheme(ThemeViewModel model)
        {
            var theme = db.Themes.FirstOrDefault(s => s.Id == model.Id);

            if (theme == null) return;
            
            db.Themes.Remove(theme);
            db.SaveChanges();
        }

        public SectionViewModel UpdateSection(SectionViewModel model)
        {
            var updateSection = db.Sections.FirstOrDefault(x => x.Id == model.Id);
            if (updateSection != null)
            {
                updateSection.Title = model.Title;
                updateSection.ImageUrl = model.ImageUrl;
                db.SaveChanges();
            }

            var updatedSection = db.Sections.FirstOrDefault(x => x.Id == updateSection.Id);

            return mapper.Map<SectionViewModel>(updatedSection);
        }
        
        public SubsectionViewModel UpdateSubsection(SubsectionViewModel model)
        {
            var updateSubsection = db.Subsections.FirstOrDefault(x => x.Id == model.Id);
            if (updateSubsection != null)
            {
                updateSubsection.Title = model.Title;
                updateSubsection.SectionId = model.SectionId;
                updateSubsection.ImageUrl = model.ImageUrl;
                updateSubsection.VideoUrl = model.VideoUrl;
                updateSubsection.Text = model.Text;
                db.SaveChanges();
            }

            var updatedSubsection = db.Subsections.Include(x => x.Section).FirstOrDefault(x => x.Id == updateSubsection.Id);

            return mapper.Map<SubsectionViewModel>(updatedSubsection);
        }

        public TestViewModel GetTestByThemeId(int id)
        {
            var testByTheme = db.Tests.FirstOrDefault(x => x.SubsectionId == id);

            return mapper.Map<TestViewModel>(testByTheme);
        }

        public List<QuestionAnswerOptionViewModel> GetFreeQuestionByTestId(int id, string userId)
        {
            var question = db.QuestionAnswerOptions
                .Include(x => x.Question)
                .ThenInclude(x => x.Test)
                .Include(x => x.AnswerOption)
                .Where(x => !db.ResponseHistories
                    .Any(y => (y.Question.QuestionId == x.Question.Id && y.UserId == userId && x.QuestionId == id) && x.Question.Test.Id == id)).ToList();

            return mapper.Map<List<QuestionAnswerOptionViewModel>>(question);
        }

        public TestResultViewModel GetResultTestByTestIdUserId(string userId, int testId)
        {
            var userAnswers =
                db.ResponseHistories
                    .Include(x => x.Question)
                    .ThenInclude(x => x.Question)
                    .Where(x => x.Question.Question.Test.Id == testId && x.UserId == userId && x.Question.IsCorrectly).ToList();

            int userPoints = 0;

            foreach (var item in userAnswers)
            {
                userPoints += item.Question.Question.Point;
            }

            return new TestResultViewModel() {Points = userPoints, TestId = testId, UserId = userId};
        }

        public int MaxPointsInTest(int testId)
        {
            var userAnswers =
                db.Questions.Where(x => x.Test.Id == testId).ToList();
            
            int points = 0;

            foreach (var item in userAnswers)
            {
                points += item.Point;
            }

            return points;
        }
        public ThemeViewModel UpdateTheme(ThemeViewModel model)
        {
            var updateTheme = db.Themes.FirstOrDefault(x => x.Id == model.Id);
            if (updateTheme != null)
            {
                updateTheme.Name = model.Name;
                updateTheme.SubsectionId = model.SubsectionId;
                updateTheme.ImageUrl = model.ImageUrl;
                updateTheme.VideoUrl = model.VideoUrl;
                updateTheme.SoundUrl = model.SoundUrl;
                updateTheme.Text = model.Text;
                db.SaveChanges();
            }

            var updatedTheme = db.Subsections
                .Include(x => x.Section).FirstOrDefault(x => x.Id == updateTheme.Id);

            return mapper.Map<ThemeViewModel>(updatedTheme);
        }

        public void AddAnswerToQuestion(string userId, int answerId)
        {
            db.ResponseHistories.Add(new ResponseHistory(){ UserId = userId, QuestionId = answerId });
            db.SaveChanges();
        }

        public IEnumerable<SubsectionViewModel> GetAllSubsections()
        {
            var subsections = db.Subsections.Include(x => x.Section).ToList();

            return mapper.Map<IEnumerable<SubsectionViewModel>>(subsections);
        }
        
        public IEnumerable<ThemeViewModel> GetAllThemes()
       {
          var themes = db.Themes.Include(x => x.Subsection).ToList();

          return mapper.Map<IEnumerable<ThemeViewModel>>(themes);
        }
        
        public SectionViewModel CreateSection(SectionViewModel model)
        {
            if (model != null)
            {
                db.Sections.Add(mapper.Map<Section>(model));
                db.SaveChanges();
            }

            var addedSection = db.Sections.FirstOrDefault(x => x.Id == model.Id);

            return mapper.Map<SectionViewModel>(addedSection);
        }
        
        public SubsectionViewModel CreateSubsection(SubsectionViewModel model)
        {
            var addSubsection = mapper.Map<Subsection>(model);
            if (model != null)
            {
                db.Subsections.Add(addSubsection);
                db.SaveChanges();
            }

            var addedSubsection = db.Subsections.Include(x => x.Section).FirstOrDefault(x => x.Id == addSubsection.Id);

            return mapper.Map<SubsectionViewModel>(addedSubsection);
        }
        
        public ThemeViewModel CreateTheme(ThemeViewModel model)
        {
            var addTheme = mapper.Map<Theme>(model);
            if (model != null)
            {
                db.Themes.Add(addTheme);
                db.SaveChanges();
            }

            var addedTheme = db.Themes.Include(x => x.Subsection).FirstOrDefault(x => x.Id == addTheme.Id);

            return mapper.Map<ThemeViewModel>(addedTheme);
        }

        public async Task<ThemeViewModel> GetThemeBySubsectionId(int id)
        {
            var theme = await db.Themes.Include(x => x.Subsection).FirstOrDefaultAsync(x => x.SubsectionId == id);
            
            return mapper.Map<ThemeViewModel>(theme);
        }
        
        public async Task<List<ThemeViewModel>> GetThemesBySubsectionId(int id)
        {
            var themes = await db.Themes.Include(x => x.Subsection).Where(x => x.SubsectionId == id).ToListAsync();
            
            return mapper.Map<List<ThemeViewModel>>(themes);
        }

    }
}