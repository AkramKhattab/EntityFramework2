using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C42_G04_EF02.Entities
{
    public class Department
    {
        public int Id { get; set; } // Primary key
        public string DeptName { get; set; } // Department name
        public int? ManagerId { get; set; } // Foreign key to Employee (Manager) (nullable)
        public Employee Manager { get; set; } // Navigation property to Employee (Manager)
        public ICollection<Employee> Employees { get; set; } // Navigation property for employees in the department
    }
}