using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.DataContext
{
    public class ClassRegisterDataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectCard> SubjectCards { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeachersSubjects { get; set; }

        public ClassRegisterDataContext(DbContextOptions<ClassRegisterDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
