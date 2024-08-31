using C42_G04_EF02.Configurations;
using C42_G04_EF02.Entities;
using Microsoft.EntityFrameworkCore;

namespace C42_G04_EF02.Contexts
{
    public class AppDbContext : DbContext
    {
        // DbSet properties for each entity
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection
            optionsBuilder.UseSqlServer("Server=Akram; Database=AppDbBG02; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            // Configure many-to-many relationship between Student and Course
            modelBuilder.Entity<StudentCourse>()
                .HasKey(SC => new { SC.StudentId, SC.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(SC => SC.Student)
                .WithMany(S => S.Courses)
                .HasForeignKey(SC => SC.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(SC => SC.Course)
                .WithMany(C => C.Students)
                .HasForeignKey(SC => SC.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .Property(sc => sc.Grade)
                .HasPrecision(5, 2); // This sets precision to 5 and scale to 2

            // Configure one-to-many relationship between Department and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(E => E.WorkFor)
                .WithMany(D => D.Employees)
                .HasForeignKey(E => E.WorkForId)
                .OnDelete(DeleteBehavior.Restrict);

  

            // Configure one-to-one relationship between Department and Employee (Manager)
            modelBuilder.Entity<Department>()
                .HasOne(D => D.Manager)
                .WithOne(E => E.ManagedDepartment)
                .HasForeignKey<Department>(D => D.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<CourseInstructor>()
            .HasKey(CI => new { CI.InstructorId, CI.CourseId });
            modelBuilder.Entity<CourseInstructor>()
            .HasOne(ci => ci.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(ci => ci.InstructorId);

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci => ci.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(ci => ci.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }

}