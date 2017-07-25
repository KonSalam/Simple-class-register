using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SimpleClassRegisterApp.Services.TeacherServices.Interfaces;
using SimpleClassRegisterApp.Models;

namespace SimpleClassRegisterApp.Services.TeacherServices
{
    public class TeacherSubjectsService : ITeacherSubjectsService
    {
        private readonly ClassRegisterDataContext _db;

        public TeacherSubjectsService(ClassRegisterDataContext db)
        {
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
    }
}
