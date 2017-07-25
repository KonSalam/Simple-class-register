using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Servies.StudentServices.Interfaces
{
    public interface IStudentClassesService
    {
        Task<StudentClassesViewModel> GetAllClasses(string user);
        Task SetClasses(string identification, string user);
        Task SetSubjectsCardsToStudent(string user);
        Task<IEnumerable<SubjectCard>> GetSubjectsMarks(string user);
    }
}
