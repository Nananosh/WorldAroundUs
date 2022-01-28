using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorldAroundUs.Models;

namespace WorldAroundUs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionService sectionService;
        
        public HomeController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        public IActionResult Index()
        {
            var allSections = sectionService.GetAllSections();
            
            return View(allSections);
        }

        public async Task<IActionResult> Subsections(int id)
        {
            var subSection = await sectionService.GetSubsectionBySectionId(id);

            if (subSection == null) return RedirectToAction("Index");
            
            return View(subSection);
        }
        
        public async Task<IActionResult> Themes(int id)
        {
            var themes = await sectionService.GetThemesBySubsectionId(id);

            if (themes == null) return RedirectToAction("Index");
            
            return View(themes);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}