using EF2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EF2.Data
{
    internal class DBcontext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server= .;Database= School;Trusted_Connection= true;trustservercertificate= true"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());




        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
    
}
