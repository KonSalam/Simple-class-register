using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using SimpleClassRegisterApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClassRegisterDataContext _db;
        
        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, ClassRegisterDataContext db)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _db = db;
        }

        public async Task<SignInResult> LoginUser(LoginViewModel login)
        {
            var result = await _signinManager.PasswordSignInAsync(
                login.EmailAddress, login.Password,
                login.RememberMe, false
            );

            return result;
        }

        public async Task LogoutUser()
        {
            await _signinManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUser(SignUpViewModel registration)
        {
            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            var newStudent = new Student
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Mail = registration.EmailAddress
            };

            var result = await _userManager.CreateAsync(newUser, registration.Password);

            return result;
        }

        public void RegisterStudent(SignUpViewModel registration)
        {
            var newStudent = new Student
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Mail = registration.EmailAddress
            };

            _db.Students.Add(newStudent);
            _db.SaveChanges();
        }

    }
}