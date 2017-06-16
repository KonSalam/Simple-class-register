using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models
{
    public class SubjectCard
    {
        public int SubjectCardID { get; set; }
        public float Average { get; set; }
        public int Grade { get; set; }
        public ICollection<Mark> Marks { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int TeacherSubjectID { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
    }
}
