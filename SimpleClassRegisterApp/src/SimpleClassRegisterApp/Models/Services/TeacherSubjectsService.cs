using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services
{
    public class TeacherSubjectsService : ITeacherSubjectsService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClassRegisterDataContext _db;

        public TeacherSubjectsService(UserManager<IdentityUser> userManager, ClassRegisterDataContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<TeacherSubjectsViewModel> GetAllSubjects(string user)
        {
            var subjects = await _db.Subjects.ToListAsync();
            var teacher = await _db.Teachers.Include(x=>x.TeacherSubject).FirstOrDefaultAsync(x => x.Mail == user);

            var teacherSubjectsViewModel = new TeacherSubjectsViewModel
            {
                Subjects = subjects,
                Teacher = teacher
            };

            return teacherSubjectsViewModel;
        }

        public async Task AddTeacherSubject(string subjectName, string user)
        {
            var subject = await _db.Subjects.FirstOrDefaultAsync(x => x.Name == subjectName);
            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Mail == user);

            await _db.TeacherSubjects.AddAsync(new TeacherSubject
            {
                SubjectID = subject.SubjectID,
                TeacherID = teacher.TeacherID
            });

            await _db.SaveChangesAsync();
        }

        public async Task<TeacherSubjectsViewModel> GetAllClasses(string user)
        {
            var classes = await _db.Classes.ToListAsync();
            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Mail == user);

            var teacherClassesViewModel = new TeacherSubjectsViewModel
            {
                Teacher = teacher
            };

            return teacherClassesViewModel;
        }
    }
}
