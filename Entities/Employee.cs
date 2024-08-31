using C42_G04_EF02.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C42_G04_EF02.Entities
{
    public class Employee
    {
        public int Id { get; set; } // Primary key
        public string EmployeeName { get; set; } // Employee name
        public string Address { get; set; } // Employee address
        public int Age { get; set; } // Employee age
        public int? WorkForId { get; set; } // Foreign key to Department (nullable)
        public decimal? Salary { get; set; } // Employee salary (nullable)
        public virtual Department WorkFor { get; set; } // Navigation property to Department
        public Department ManagedDepartment { get; set; } // Navigation property for managed department (one-to-one)
    }
}
