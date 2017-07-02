﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherSubjectClasses> TeachersSubjectsClasses { get; set; }
        public ICollection<TeacherSubject> TeacherSubject { get; set; }
    }
}
