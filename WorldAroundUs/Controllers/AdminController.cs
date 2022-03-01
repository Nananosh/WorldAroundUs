using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using WorldAroundUs.Business.Interfaces;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISectionService sectionService;
        private readonly IAdminService adminService;

        public AdminController(
            ISectionService sectionService,
            IAdminService adminService)
        {
            this.adminService = adminService;
            this.sectionService = sectionService;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult AdminSection()
        {
            return View();
        }

        public IActionResult AdminSubsection()
        {
            return View();
        }

        public JsonResult GetAllTests()
        {
            var tests = adminService.GetAllTests();

            return Json(tests);
        }

        [HttpPost]
        public IActionResult UpdateTest(TestViewModel model)
        {
            var test = adminService.UpdateTest(model);

            return Json(test);
        }

        [HttpDelete]
        public Test RemoveTest(TestViewModel model)
        {
            adminService.RemoveTest(model);

            return new Test();
        }

        public JsonResult GetAllAnswerOptionText()
        {
            var answerOption = adminService.GetAllAnswerOptions();

            return Json(answerOption);
        }

        [HttpPost]
        public IActionResult UpdateAnswerOptionText(AnswerOptionViewModel model)
        {
            var test = adminService.UpdateAnswerOptions(model);

            return Json(test);
        }

        [HttpDelete]
        public AnswerOption RemoveAnswerOptionText(AnswerOptionViewModel model)
        {
            adminService.RemoveAnswerOption(model);

            return new AnswerOption();
        }

        public IActionResult AdminTheme()
        {
            return View();
        }

        public IActionResult AdminAnswerOptionText()
        {
            return View();
        }

        public IActionResult TestGrid()
        {
            return View();
        }

        public IActionResult AnswerQuestion()
        {
            return View();
        }

        public IActionResult QuestionGrid()
        {
            return View();
        }

        public JsonResult GetAllSections()
        {
            var sections = sectionService.GetAllSections();

            return Json(sections);
        }

        public JsonResult GetAllQuestions()
        {
            var questions = adminService.GetAllQuestions();

            return Json(questions);
        }

        public JsonResult GetAllQuestionAnswerOptions()
        {
            var answerQuestions = adminService.GetAllQuestionAnswerOptions();

            return Json(answerQuestions);
        }

        [HttpPost]
        public IActionResult CreateTest(TestViewModel model)
        {
            var test = adminService.CreateTest(model);

            return Json(test);
        }

        [HttpPost]
        public IActionResult CreateQuestion(QuestionViewModel model)
        {
            var question = adminService.CreateQuestion(model);

            return Json(question);
        }

        [HttpPost]
        public IActionResult CreateAnswerOptionText(AnswerOptionViewModel model)
        {
            var question = adminService.CreateAnswerOption(model);

            return Json(question);
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
        public JsonResult UpdateQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            var sections = adminService.UpdateQuestionAnswerOption(model);

            return Json(sections);
        }

        [HttpPost]
        public JsonResult UpdateQuestion(QuestionViewModel model)
        {
            var question = adminService.UpdateQuestion(model);

            return Json(question);
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
        public JsonResult CreateQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            var subsection = adminService.CreateQuestionAnswerOption(model);

            return Json(subsection);
        }

        [HttpPost]
        public JsonResult CreateTheme(ThemeViewModel model)
        {
            var theme = sectionService.CreateTheme(model);

            return Json(theme);
        }

        [HttpDelete]
        public Section RemoveSection(SectionViewModel model)
        {
            sectionService.RemoveSection(model);
            return new Section();
        }

        [HttpDelete]
        public QuestionAnswerOption RemoveQuestionAnswerOption(QuestionAnswerOptionViewModel model)
        {
            adminService.RemoveQuestionAnswerOption(model);

            return new QuestionAnswerOption();
        }

        [HttpDelete]
        public Question RemoveQuestion(QuestionViewModel model)
        {
            adminService.RemoveQuestion(model);

            return new Question();
        }

        [HttpDelete]
        public Subsection RemoveSubsection(SubsectionViewModel model)
        {
            sectionService.RemoveSubsection(model);

            return new Subsection();
        }

        [HttpDelete]
        public Theme RemoveTheme(ThemeViewModel model)
        {
            sectionService.RemoveTheme(model);

            return new Theme();
        }

        public JsonResult GetAllSubsections()
        {
            var subsections = sectionService.GetAllSubsections();

            return Json(subsections);
        }

        public JsonResult GetAllAnswerOption()
        {
            var subsections = sectionService.GetAllAnswerOption();

            return Json(subsections);
        }
    }
}