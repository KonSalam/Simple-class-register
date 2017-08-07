using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using System.Linq;

namespace SimpleClassRegisterApp
{
    public static class DbInitializer
    {
        public static void Initialize(ClassRegisterDataContext context)
        {
            if (context.Classes.Any())
            {
                return;
            }

            var newSubjects = new Subject[]
            {
                new Subject{Name="Math"},
                new Subject{Name="English"},
                new Subject{Name="Polish"},
                new Subject{Name="Chemistry"},
                new Subject{Name="Biology"},
                new Subject{Name="Geography"},
                new Subject{Name="Physics" }
            };

            foreach (Subject element in newSubjects)
            {
                context.Subjects.Add(element);
            }
            context.SaveChanges();

            var newClasses = new Class[]
            {
                new Class{Identification="1 A"},
                new Class{Identification="1 B"},
                new Class{Identification="2 A"},
                new Class{Identification="2 B"},
                new Class{Identification="3 A"},
                new Class{Identification="3 B"}
            };

            foreach (Class element in newClasses)
            {
                context.Classes.Add(element);
            }
            context.SaveChanges();

            var classes = context.Classes.ToList();
            var subjects = context.Subjects.ToList();

            foreach (Class element in classes)
            {
                foreach (Subject subject in subjects)
                {
                    context.TeacherSubjectClasses.Add(new TeacherSubjectClasses
                    {
                        ClassID = element.ClassID,
                        SubjectID = subject.SubjectID
                    });
                }
            }
            context.SaveChanges();
        }
    }
}