using SimpleClassRegisterApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleClassRegisterApp.ViewModels
{
    public class TeacherMarksViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}