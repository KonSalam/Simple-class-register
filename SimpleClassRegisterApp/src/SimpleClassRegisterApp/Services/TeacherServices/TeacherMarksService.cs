using Microsoft.EntityFrameworkCore;
using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using SimpleClassRegisterApp.Services.TeacherServices.Interfaces;
using SimpleClassRegisterApp.ViewModels;
using System;
using System.Linq;
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
            var classes = await _db.Classes.ToListAsync();
            var teacher = await _db.Teachers
                .Include(x => x.TeacherSubject)
                .Include(x => x.TeachersSubjectsClasses)
                .FirstOrDefaultAsync(x => x.Mail == user);

            var teacherMarksViewModel = new TeacherMarksViewModel
            {
                Teacher = teacher,
                Classes = classes
            };

            return teacherMarksViewModel;
        }

        public async Task<TeacherMarksViewModel> GetClassStudents(int classId, int subjectId)
        {
            var students = await _db.Students.Where(x => x.ClassID == classId)
                .Include(x => x.SubjectCards)
                     .ThenInclude(x => x.TeacherSubjectClasses)
                     .ThenInclude(z => z.SubjectsCards)
                     .ThenInclude(c => c.Marks)
                .ToListAsync();

            var subject = await _db.Subjects.Where(x => x.SubjectID == subjectId).ToListAsync();

            var viewModel = new TeacherMarksViewModel
            {
                Students = students,
                Subjects = subject
            };

            return viewModel;
        }

        public async Task AddMark(int subjectCardId, int grade)
        {
            var mark = new Mark
            {
                SubjectCardID = subjectCardId,
                Grade = grade,
                InsertionDate = DateTime.Now
            };

            await _db.Marks.AddAsync(mark);
            await _db.SaveChangesAsync();
        }

    }
}