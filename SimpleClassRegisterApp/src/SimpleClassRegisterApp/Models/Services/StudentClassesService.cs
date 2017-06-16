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
    public class StudentClassesService : IStudentClassesService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClassRegisterDataContext _db;

        public StudentClassesService(UserManager<IdentityUser> userManager, ClassRegisterDataContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<StudentClassesViewModel> GetAllClasses(string user)
        {
            var classes = await _db.Classes.ToListAsync();
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);

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

            student.Class = classes;
            _db.SaveChanges();
        }

        public void SetSubjectsCardsToStudent(string user)
        {
            var subjects = _db.Subjects.ToList();
            var student = _db.Students.FirstOrDefault(x => x.Mail == user);

            foreach (Subject subject in subjects)
            {
                var teacherSubject = _db.TeachersSubjects.FirstOrDefault(x => x.ClassID == student.ClassID && x.SubjectID == subject.SubjectID);

                _db.SubjectCards.Add(new SubjectCard
                {
                    StudentID = student.StudentID,
                    TeacherSubject = teacherSubject
                });
            }

            _db.Students.Include(x => x.SubjectCards).ToList();
            _db.SaveChanges();
        }

        public async Task<IEnumerable<SubjectCard>> GetSubjectsMarks(string user)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);
            var subjectsCards = _db.SubjectCards.Include(s => s.TeacherSubject).ThenInclude(s=>s.Subject).Where(s => s.StudentID == student.StudentID).Include(s => s.Marks);

            return subjectsCards;
        }

    }
}