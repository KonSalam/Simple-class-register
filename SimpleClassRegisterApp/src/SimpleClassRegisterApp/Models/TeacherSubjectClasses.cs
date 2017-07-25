using System.Collections.Generic;

namespace SimpleClassRegisterApp.Models
{
    public class TeacherSubjectClasses
    {
        public int TeacherSubjectClassesID { get; set; }
        public ICollection<SubjectCard> SubjectsCards { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public int? TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int ClassID { get; set; }
        public Class Class { get; set; }
    }
}
