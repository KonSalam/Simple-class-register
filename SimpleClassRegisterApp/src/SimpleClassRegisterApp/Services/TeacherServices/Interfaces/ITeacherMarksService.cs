using SimpleClassRegisterApp.ViewModels;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Services.TeacherServices.Interfaces
{
    public interface ITeacherMarksService
    {
        Task<TeacherMarksViewModel> GetTeacherSubjectClasses(string user);
        Task<TeacherMarksViewModel> GetClassStudents(int classId, int subjectId);
        Task AddMark(int subjectCardId, int grade);
    }
}
