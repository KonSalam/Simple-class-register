using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using SimpleClassRegisterApp.ViewModels;

namespace SimpleClassRegisterApp.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("Teacher")]
    public class TeacherSubjectsController : Controller
    {
        private readonly ITeacherSubjectsService _teacherSubjectsService;
        private readonly ITeacherClassesService _teacherClassesService;

        public TeacherSubjectsController(ITeacherSubjectsService teacherSubjectsService, ITeacherClassesService teacherClassesService)
        {
            _teacherSubjectsService = teacherSubjectsService;
            _teacherClassesService = teacherClassesService;
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

    }
}
