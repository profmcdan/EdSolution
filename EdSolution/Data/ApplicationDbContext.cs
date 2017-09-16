using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EdSolution.Models;

namespace EdSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Student>().ToTable("Student");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<Department>().ToTable("Department");
            builder.Entity<Instructor>().ToTable("Instructor");
            builder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            builder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            builder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
            builder.Entity<Department>()
                .Property(p => p.RowVersion).IsConcurrencyToken();
        }
    }
}
