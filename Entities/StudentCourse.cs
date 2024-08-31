using System.ComponentModel.DataAnnotations.Schema;

namespace C42_G04_EF02.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; } // Part of composite key, foreign key to Student
        public int CourseId { get; set; } // Part of composite key, foreign key to Course
        public decimal Grade { get; set; } // Student's grade for the course
        public Student Student { get; set; } // Navigation property to Student
        public Course Course { get; set; } // Navigation property to Course
    }
}