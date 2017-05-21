using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
