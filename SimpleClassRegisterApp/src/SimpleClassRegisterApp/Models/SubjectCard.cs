﻿using System.Collections.Generic;

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
        public int TeacherSubjectClassesID { get; set; }
        public TeacherSubjectClasses TeacherSubjectClasses { get; set; }
    }
}
