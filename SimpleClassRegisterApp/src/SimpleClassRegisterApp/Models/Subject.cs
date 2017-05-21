using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        ICollection<SubjectCard> SubjectCards { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
