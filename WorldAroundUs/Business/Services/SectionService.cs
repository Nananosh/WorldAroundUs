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
using WorldAroundUs.ViewModels;
using WorldAroundUs.Models;

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
                updateSubsection.Age = model.Age;
                updateSubsection.Continent = model.Continent;
                updateSubsection.Height = model.Height;
                updateSubsection.Weight = model.Weight;
                db.SaveChanges();
            }

            var updatedSubsection = db.Subsections.Include(x => x.Section).FirstOrDefault(x => x.Id == updateSubsection.Id);

            return mapper.Map<SubsectionViewModel>(updatedSubsection);
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