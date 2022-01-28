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

        public async Task<IActionResult> Subsections(int id, string theme)
        {
            var subSection = await sectionService.GetSubsectionBySectionId(id);
            ViewBag.Theme = theme;

            return View(subSection);
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