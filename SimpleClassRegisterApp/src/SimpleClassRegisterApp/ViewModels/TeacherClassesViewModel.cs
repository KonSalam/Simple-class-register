using SimpleClassRegisterApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleClassRegisterApp.ViewModels
{
    public class TeacherClassesViewModel
    {
        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public Teacher Teacher { get; set; }
    }
}