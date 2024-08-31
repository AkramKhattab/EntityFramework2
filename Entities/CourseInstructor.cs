namespace C42_G04_EF02.Entities
{
    public class CourseInstructor
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public string Evaluate { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}