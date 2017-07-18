using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services.Interfaces
{
    public interface ITeacherSubjectsService
    {
        Task<TeacherSubjectsViewModel> GetAllSubjects(string user);
        Task AddTeacherSubject(string subjectName, string user);
    }
}
