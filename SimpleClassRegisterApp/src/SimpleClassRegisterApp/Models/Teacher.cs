using System.Collections.Generic;

namespace SimpleClassRegisterApp.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public ICollection<TeacherSubjectClasses> TeachersSubjectsClasses { get; set; }
        public ICollection<TeacherSubject> TeacherSubject { get; set; }
    }
}
