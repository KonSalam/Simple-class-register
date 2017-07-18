using SimpleClassRegisterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.ViewModels
{
    public class TeacherSubjectsViewModel
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public Teacher Teacher { get; set; }
    }
}
