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
                updateSubsection.Description = model.Description;
                updateSubsection.ImageUrl = model.ImageUrl;
                updateSubsection.VideoUrl = model.VideoUrl;
                db.SaveChanges();
            }

            var updatedSubsection = db.Subsections.Include(x => x.Section).FirstOrDefault(x => x.Id == updateSubsection.Id);

            return mapper.Map<SubsectionViewModel>(updatedSubsection);
        }

        public IEnumerable<SubsectionViewModel> GetAllSubsections()
        {
            var subsections = db.Subsections.Include(x => x.Section).ToList();

            return mapper.Map<IEnumerable<SubsectionViewModel>>(subsections);
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

    }
}