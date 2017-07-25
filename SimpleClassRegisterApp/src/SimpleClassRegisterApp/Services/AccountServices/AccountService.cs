using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Servies.AccountServies.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Servies.AccountServies
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ClassRegisterDataContext _db;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager,
            RoleManager<IdentityRole> roleManager, ClassRegisterDataContext db)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
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

        public async Task<IdentityResult> RegisterUser(SignUpViewModel registration)
        {
            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            var createResult = await _userManager.CreateAsync(newUser, registration.Password);

            if (createResult.Succeeded)
            {
                await AddUserRole(newUser, registration);
            }

            return createResult;
        }

        public async Task AddUserRole(IdentityUser newUser, SignUpViewModel registration)
        {
            if (registration.AccountType == "Student")
            {
                await _userManager.AddToRoleAsync(newUser, "Student");
                RegisterStudent(registration);
            }
            else
            {
                await _userManager.AddToRoleAsync(newUser, "Teacher");
                RegisterTeacher(registration);
            }
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

        public void RegisterTeacher(SignUpViewModel registration)
        {
            var newTeacher = new Teacher
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Mail = registration.EmailAddress
            };

            _db.Teachers.Add(newTeacher);
            _db.SaveChanges();
        }

        public async Task LogoutUser()
        {
            await _signinManager.SignOutAsync();
        }

    }
}