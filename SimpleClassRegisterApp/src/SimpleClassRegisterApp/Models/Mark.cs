using System;

namespace SimpleClassRegisterApp.Models
{
    public class Mark
    {
        public int MarkID { get; set; }
        public int Grade { get; set; }
        public DateTime InsertionDate { get; set; }

        public int SubjectCardID { get; set; }
        public SubjectCard SubjectCard { get; set; }
    }
}
