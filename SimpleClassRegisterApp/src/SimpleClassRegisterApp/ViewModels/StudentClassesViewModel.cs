using SimpleClassRegisterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.ViewModels
{
    public class StudentClassesViewModel
    {
       public IEnumerable<Class> StudentClasses { get; set; }
       public Student Student { get; set; }
    }
}
