using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Servies.StudentServices.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Servies.StudentServices
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

        public async Task SetClasses(string identification, string user)
        {
            var classes = await _db.Classes.FirstOrDefaultAsync(x => x.Identification == identification);
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);

            student.Class = classes;
            await _db.SaveChangesAsync();
        }

        public async Task SetSubjectsCardsToStudent(string user)
        {
            var subjects = await _db.Subjects.ToArrayAsync();
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);

            foreach (Subject subject in subjects)
            {
                var teacherSubjectClasses = await _db.TeacherSubjectClasses.FirstOrDefaultAsync(x => x.ClassID == student.ClassID && x.SubjectID == subject.SubjectID);

                await _db.SubjectCards.AddAsync(new SubjectCard
                {
                    StudentID = student.StudentID,
                    TeacherSubjectClasses = teacherSubjectClasses
                });
            }

            _db.Students.Include(x => x.SubjectCards).ToList();
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubjectCard>> GetSubjectsMarks(string user)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);
            var subjectsCards = _db.SubjectCards.Include(s => s.TeacherSubjectClasses).ThenInclude(s => s.Subject).Where(s => s.StudentID == student.StudentID).Include(s => s.Marks);

            return subjectsCards;
        }

    }
}