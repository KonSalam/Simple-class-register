using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Services.TeacherServices.Interfaces
{
    public interface ITeacherMarksService
    {
        Task<TeacherMarksViewModel> GetTeacherSubjectClasses(string user);
        Task SendChoice(string user);
        Task<TeacherMarksViewModel> GetStudentList(string user);
    }
}
