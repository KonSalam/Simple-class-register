using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleClassRegisterApp.ViewModels;
using SimpleClassRegisterApp.Services.TeacherServices.Interfaces;

namespace SimpleClassRegisterApp.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("Teacher")]
    public class TeacherSubjectsController : Controller
    {
        private readonly ITeacherSubjectsService _teacherSubjectsService;
        private readonly ITeacherClassesService _teacherClassesService;
        private readonly ITeacherMarksService _teacherMarksService;

        public TeacherSubjectsController(ITeacherSubjectsService teacherSubjectsService, ITeacherClassesService teacherClassesService, ITeacherMarksService teacherMarksService)
        {
            _teacherSubjectsService = teacherSubjectsService;
            _teacherClassesService = teacherClassesService;
            _teacherMarksService = teacherMarksService;
        }

        [Route("Subjects")]
        public async Task<IActionResult> Subjects()
        {
            return View(await _teacherSubjectsService.GetAllSubjects(User.Identity.Name));
        }

        [HttpPost, Route("Subjects")]
        public async Task<IActionResult> Subjects([FromBody]string subjectName)
        {
            await _teacherSubjectsService.AddTeacherSubject(subjectName, User.Identity.Name);
            return Json(Url.Action("Subjects", "TeacherSubjects"));
        }

        [Route("Classes")]
        public async Task<IActionResult> Classes()
        {
            return View(await _teacherClassesService.GetTeacherSubjectClasses(User.Identity.Name));
        }

        [HttpPost, Route("Classes")]
        public async Task<IActionResult> Classes(TeacherClassesViewModel teacherClasses)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Classes");
            }

            await _teacherClassesService.SetTeacherSubjectClasses(teacherClasses, User.Identity.Name);
            return RedirectToAction("Classes");
        }

        [HttpPost, Route("AvailableSubjectsForClass")]
        public async Task<IActionResult> AvailableSubjectsForClass([FromBody] string classId)
        {
            return Json(await _teacherClassesService.GetSubjectsAvailableForClass(classId, User.Identity.Name));
        }


        [Route("Marks")]
        public async Task<IActionResult> Marks()
        {
            return View(await _teacherMarksService.GetTeacherSubjectClasses(User.Identity.Name));
        }

        [HttpPost, Route("Marks")]
        public async Task<IActionResult> Marks(TeacherMarksViewModel teacherMarks) // nie wiem czy to bd potrzebne
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Marks");
            }

            var subject = (Request.Form["Subject"]).ToString();
            var clas = (Request.Form["Class"]).ToString();

            ViewData["subject"] = subject;
            ViewData["clas"] = clas;

            await _teacherMarksService.SendChoice(User.Identity.Name);
            return RedirectToAction("Marks");
        }
    }
}