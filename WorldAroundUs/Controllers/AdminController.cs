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

        public JsonResult GetAllSections()
        {
            var sections = sectionService.GetAllSections();

            return Json(sections);
        }
        
        [HttpPost]
        public JsonResult UpdateSection(SectionViewModel model)
        {
            var sections = sectionService.UpdateSection(model);

            return Json(sections);
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

        public JsonResult GetAllSubsections()
        {
            var subsections = sectionService.GetAllSubsections();

            return Json(subsections);
        }
    }
}