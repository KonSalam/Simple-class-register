using SimpleClassRegisterApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleClassRegisterApp.ViewModels
{
    public class TeacherMarksViewModel
    {
        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<SubjectCard> SubjectCards { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
        public SubjectCard SubjectCard { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}