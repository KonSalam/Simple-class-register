﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string Identification { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
