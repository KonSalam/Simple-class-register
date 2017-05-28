using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleClassRegisterApp.Models.Services
{
    public class StudentClassesService : IStudentClassesService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClassRegisterDataContext _db;

        public StudentClassesService(UserManager<IdentityUser> userManager, ClassRegisterDataContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public StudentClassesViewModel GetAllClasses(string user)
        {
            var classes = _db.Classes.ToList();
            var student = _db.Students.FirstOrDefault(x => x.Mail == user);

            var studentClassesViewModel = new StudentClassesViewModel
            {
                StudentClasses = classes,
                Student = student
            };

            return studentClassesViewModel;
        }

        public void SetClasses(string identification, string user)
        {
            var classes = _db.Classes.FirstOrDefault(x => x.Identification == identification);
            var student = _db.Students.FirstOrDefault(x => x.Mail == user);

            student.ClassID = classes.ClassID;
            _db.SaveChanges();
        }
    }
}