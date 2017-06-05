using SimpleClassRegisterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services.Interfaces
{
   public interface IStudentClassesService
    {
        Task<StudentClassesViewModel> GetAllClasses(string user);
        void SetClasses(string identification, string user);
        void SetSubjectsCardsToStudent(string user);
        Task<IEnumerable<SubjectCard>> GetSubjectsMarks(string user);
    }
}
