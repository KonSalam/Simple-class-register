using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp.Models.DataContext
{
    public class ClassRegisterDataContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectCard> SubjectCards { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ClassRegisterDataContext(DbContextOptions<ClassRegisterDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(p => p.SubjectCards).WithOne(c => c.Student) .HasForeignKey(c => c.StudentID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
