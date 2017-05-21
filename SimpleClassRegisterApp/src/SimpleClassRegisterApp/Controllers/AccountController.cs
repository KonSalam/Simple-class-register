using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleClassRegisterApp.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleClassRegisterApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel register)
        {

            if (!ModelState.IsValid)
            {
                return View(new SignUpViewModel());
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel register)
        {

            if (!ModelState.IsValid)
            {
                return View(new LoginViewModel());
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
