using System.ComponentModel.DataAnnotations;

namespace C42_G04_EF02.Entities
{
    public class Course
    {
        public int Id { get; set; } // Primary key
        public int Duration { get; set; }

        public string Name { get; set; } // Course name
        public string Description { get; set; }
        public Topic Topic { get; set; }

        public ICollection<StudentCourse> Students { get; set; } // Navigation property for students
        public ICollection<CourseInstructor> Instructors { get; set; }
    }
}