using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<TeacherSubjectClasses> TeacherSubjectClasses { get; set; }

        public ClassRegisterDataContext(DbContextOptions<ClassRegisterDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
