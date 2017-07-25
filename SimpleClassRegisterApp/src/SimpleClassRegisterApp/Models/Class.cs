using System.Collections.Generic;

namespace SimpleClassRegisterApp.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string Identification { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<TeacherSubjectClasses> ClassTeachersSubjects { get; set; }
    }
}
