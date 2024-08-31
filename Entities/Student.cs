using System.ComponentModel.DataAnnotations;

namespace C42_G04_EF02.Entities
{
    public class Student
    {
        public int Id { get; set; } // Primary key
        public string FName { get; set; } // Student name
        public string LName { get; set; } // Student name
        public string Address { get; set; }
        public int Age { get; set; } // Student age
        public int? Dep_Id { get; set; }
        public Department Department { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } // Navigation property for courses
    }
}