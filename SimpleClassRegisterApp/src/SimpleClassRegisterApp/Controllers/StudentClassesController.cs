﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleClassRegisterApp.Servies.StudentServices.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleClassRegisterApp.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentClassesController : Controller
    {
        private readonly IStudentClassesService _studentClassesService;

        public StudentClassesController(IStudentClassesService studentClassesService)
        {
            _studentClassesService = studentClassesService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _studentClassesService.GetAllClasses(User.Identity.Name));
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody]string studentClasses)
        {
             await _studentClassesService.SetClasses(studentClasses, User.Identity.Name);
             await _studentClassesService.SetSubjectsCardsToStudent(User.Identity.Name);
            return Json(Url.Action("Index", "StudentClasses"));
        }

        public async Task<IActionResult> Marks()
        {
            return View(await _studentClassesService.GetSubjectsMarks(User.Identity.Name));
        }

    }
}
