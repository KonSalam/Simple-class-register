using Microsoft.EntityFrameworkCore;
using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Services.TeacherServices.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Services.TeacherServices
{
    public class TeacherMarksService : ITeacherMarksService
    {
        private readonly ClassRegisterDataContext _db;

        public TeacherMarksService(ClassRegisterDataContext db)
        {
            _db = db;
        }

        public async Task<TeacherMarksViewModel> GetTeacherSubjectClasses(string user)
        {
            var subject = await _db.Subjects.ToListAsync();
            var classes = await _db.Classes.ToListAsync();
            var teacher = await _db.Teachers.Include(x => x.TeacherSubject).Include(x => x.TeachersSubjectsClasses).FirstOrDefaultAsync(x => x.Mail == user);

            var teacherMarksViewModel = new TeacherMarksViewModel
            {
                Subjects = subject,
                Teacher = teacher,
                Classes = classes
            };

            return teacherMarksViewModel;
        }

        public async Task SendChoice(string user)
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

            await _db.SaveChangesAsync();
        }

        public async Task<TeacherMarksViewModel> GetStudentList(string user)
        {
            var subject = await _db.Subjects.ToListAsync();
            var classes = await _db.Classes.ToListAsync();
            var students = await _db.Students.ToListAsync();
            var teacher = await _db.Teachers.Include(x => x.TeacherSubject).Include(x => x.TeachersSubjectsClasses).FirstOrDefaultAsync(x => x.Mail == user);
            var subjectcard = _db.SubjectCards.Include(s => s.TeacherSubjectClasses).ThenInclude(s => s.Subject.Name == "Math" && s.Class.Identification == "1A").Include(s => s.Marks);
            var marks = await _db.Marks.ToListAsync();

            var teacherMarksViewModel = new TeacherMarksViewModel
            {
                Subjects = subject,
                Students = students,
                Teacher = teacher,
                Classes = classes,
                //SubjectCards = subjectcard,
                Marks = marks
            };

            return teacherMarksViewModel;
        }
    }
}