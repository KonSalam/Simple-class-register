using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services.Interfaces
{
    public interface ITeacherClassesService
    {
        Task<TeacherClassesViewModel> GetTeacherSubjectClasses(string user);
        Task SetTeacherSubjectClasses(TeacherClassesViewModel teacherClasses, string user);
    }
}
