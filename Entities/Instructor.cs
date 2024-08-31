using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G04_EF02.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public decimal HourRate { get; set; }
        public decimal Bonus { get; set; }
        public int? Dept_ID { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseInstructor> Courses { get; set; }
    }
}
