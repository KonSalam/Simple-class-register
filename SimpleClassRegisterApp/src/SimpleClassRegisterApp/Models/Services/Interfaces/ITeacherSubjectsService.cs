using SimpleClassRegisterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.Services.Interfaces
{
    public interface ITeacherSubjectsService
    {
        Task<TeacherSubjectsViewModel> GetAllSubjects(string user);
        Task AddTeacherSubject(string subjectName, string user);
        Task<TeacherSubjectsViewModel> GetAllClasses(string user);
    }
}
