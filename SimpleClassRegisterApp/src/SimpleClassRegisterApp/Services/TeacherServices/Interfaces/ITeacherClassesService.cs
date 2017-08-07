using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Services.TeacherServices.Interfaces
{
    public interface ITeacherClassesService
    {
        Task<TeacherClassesViewModel> GetTeacherSubjectClasses(string user);
        Task<List<Subject>> GetSubjectsAvailableForClass(int clasId, string user);
        Task SetTeacherSubjectClasses(TeacherClassesViewModel teacherClasses, string user);
    }
}
