using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleClassRegisterApp.Models.Services.Interfaces;

namespace SimpleClassRegisterApp.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherSubjectsController : Controller
    {
        private readonly ITeacherSubjectsService _teacherSubjectsService;

        public TeacherSubjectsController(ITeacherSubjectsService teacherSubjectsService)
        {
            _teacherSubjectsService = teacherSubjectsService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Subjects()
        {
            return View(await _teacherSubjectsService.GetAllSubjects(User.Identity.Name));
        }

        [HttpPost]
        public async Task<IActionResult> Subjects([FromBody]string subjectName)
        {
            await _teacherSubjectsService.AddTeacherSubject(subjectName, User.Identity.Name);
            return Json(Url.Action("Subjects", "TeacherSubjects"));
        }
    }
}
