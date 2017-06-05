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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetClasses(string identification, string user)
        {
            try
            {
                var classes =  _db.Classes.FirstOrDefault(x => x.Identification == identification);
                var student =  _db.Students.FirstOrDefault(x => x.Mail == user);

                student.ClassID = classes.ClassID;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetSubjectsCardsToStudent(string user)
        {
            try
            {
                var subjects = _db.Subjects.ToList();
                var student =  _db.Students.FirstOrDefault(x => x.Mail == user);

                foreach (Subject subject in subjects)
                {
                    _db.SubjectCards.Add(new SubjectCard
                    {
                        StudentID = student.StudentID,
                        SubjectID = subject.SubjectID
                    });
                }

                _db.Students.Include(x => x.SubjectCards).ToList();
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SubjectCard>> GetSubjectsMarks(string user)
        {
            try
            {
                var student = await _db.Students.FirstOrDefaultAsync(x => x.Mail == user);
                var subjectsCards =  _db.SubjectCards.Include(s => s.Subject).Where(s => s.StudentID == student.StudentID).Include(s => s.Marks);

                return subjectsCards;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}