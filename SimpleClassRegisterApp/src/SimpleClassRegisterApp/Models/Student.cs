using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public ICollection<SubjectCard> SubjectCards { get; set; }

        public int? ClassID { get; set; }
        public Class Class { get; set; }

        public Student()
        {
            SubjectCards = new List<SubjectCard>();
        }
    }
}
