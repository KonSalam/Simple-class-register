using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Services.TeacherServices.Interfaces
{
    public interface ITeacherSubjectsService
    {
        Task<TeacherSubjectsViewModel> GetAllSubjects(string user);
        Task AddTeacherSubject(string subjectName, string user);
    }
}
