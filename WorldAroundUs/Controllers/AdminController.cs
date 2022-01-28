using Microsoft.AspNetCore.Mvc;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISectionService sectionService;
        
        public AdminController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }
        
        public IActionResult AdminSection()
        {
            return View();
        }
        
        public IActionResult AdminSubsection()
        {
            return View();
        }
        
        public IActionResult AdminTheme()
        {
            return View();
        }

        public JsonResult GetAllSections()
        {
            var sections = sectionService.GetAllSections();

            return Json(sections);
        }
        
        public JsonResult GetAllThemes()
        {
            var themes = sectionService.GetAllThemes();

            return Json(themes);
        }
        
        
        [HttpPost]
        public JsonResult UpdateSection(SectionViewModel model)
        {
            var sections = sectionService.UpdateSection(model);

            return Json(sections);
        }
        
        [HttpPost]
        public JsonResult UpdateTheme(ThemeViewModel model)
        {
            var theme = sectionService.UpdateTheme(model);

            return Json(theme);
        }
        
        [HttpPost]
        public JsonResult UpdateSubsection(SubsectionViewModel model)
        {
            var sections = sectionService.UpdateSubsection(model);

            return Json(sections);
        }
        
        [HttpPost]
        public JsonResult CreateSection(SectionViewModel model)
        {
            var sections = sectionService.CreateSection(model);

            return Json(sections);
        }
        
        [HttpPost]
        public JsonResult CreateSubsection(SubsectionViewModel model)
        {
            var subsection = sectionService.CreateSubsection(model);

            return Json(subsection);
        }
        
        [HttpPost]
        public JsonResult CreateTheme(ThemeViewModel model)
        {
            var theme = sectionService.CreateTheme(model);

            return Json(theme);
        }
        
        [HttpDelete]
        public void RemoveSection(SectionViewModel model)
        {
            sectionService.RemoveSection(model);
        }
        
        [HttpDelete]
        public void RemoveSubsection(SubsectionViewModel model)
        {
            sectionService.RemoveSubsection(model);
        }
        
        [HttpDelete]
        public void RemoveTheme(ThemeViewModel model)
        {
            sectionService.RemoveTheme(model);
        }

        public JsonResult GetAllSubsections()
        {
            var subsections = sectionService.GetAllSubsections();

            return Json(subsections);
        }
    }
}