using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services.Interfaces
{
    public interface IAccountService
    {
        Task LogoutUser();
        Task<SignInResult> LoginUser(LoginViewModel login);
        Task<IdentityResult> RegisterUser(SignUpViewModel registration);
        Task AddUserRole(IdentityUser newUser, SignUpViewModel registration);
        void RegisterStudent(SignUpViewModel registration);
        void RegisterTeacher(SignUpViewModel registration);
    }
}
