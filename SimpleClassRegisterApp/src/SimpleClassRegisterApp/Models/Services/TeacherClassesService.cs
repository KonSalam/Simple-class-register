using Microsoft.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;
using System;

namespace SimpleClassRegisterApp.Models.Services
{
    public class TeacherClassesService : ITeacherClassesService
    {
        private readonly ClassRegisterDataContext _db;

        public TeacherClassesService(ClassRegisterDataContext db)
        {
            _db = db;
        }

        public async Task<TeacherClassesViewModel> GetTeacherSubjectClasses(string user)
        {
            var subject = await _db.Subjects.ToListAsync();
            var classes = await _db.Classes.ToListAsync();
            var teacher = await _db.Teachers.Include(x => x.TeacherSubject).Include(x => x.TeachersSubjectsClasses).FirstOrDefaultAsync(x => x.Mail == user);

            var teacherClassesViewModel = new TeacherClassesViewModel
            {
                Subjects = subject,
                Teacher = teacher,
                Classes = classes
            };

            return teacherClassesViewModel;
        }

        public async Task SetTeacherSubjectClasses(TeacherClassesViewModel teacherClasses, string user)
        {
            var subject = await _db.Subjects.FirstOrDefaultAsync(x => x.Name == teacherClasses.Subject);
            var classes = await _db.Classes.FirstOrDefaultAsync(x => x.Identification == teacherClasses.Class);
            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Mail == user);

            var teacherSubjectsClasses = await _db.TeacherSubjectClasses.FirstOrDefaultAsync(x => x.ClassID == classes.ClassID &&
            x.SubjectID == subject.SubjectID);

            teacherSubjectsClasses.TeacherID = teacher.TeacherID;
            await _db.SaveChangesAsync();
        }
    }
}