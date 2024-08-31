using C42_G04_EF02.Contexts;
using C42_G04_EF02.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace C42_G04_EF02
{
    internal class Program
    {
        static void Main()
        {
            #region Revision
            // EF Core: ORM in .NET
            // ORM

            //.1 Mapping
            //   Code First [Generate Table Per Class]
            //   DB First [Generate Class Per Table]
            //.2 L2E [C# Code (LINQ) ---> EF Core --> SQL DB]

            // 3 Ways Generate
            // 1. TPC : Table Per Class
            // 2. TPH : Table Per Hirarichy
            // 3. TPCC: Table Per Concret Class 
            #endregion

            #region CRUD Operation
            // Create - Read - Update - Delete

            //AppDbContext context = new AppDbContext();

            //try
            //{
            //    // Code
            //}
            //finally
            //{ 
            //    context.Dispose();
            //}

            //using (AppDbContext context = new AppDbContext())
            //{
            //    // CRUD
            //}

            //using AppDbContext context = new AppDbContext();


            #region Create - Insert

            //var employee = new Employee()
            //{
            //    Name = "Mohammed Ali",
            //    Salary = 1200,
            //    Address = "Cairo",
            //    Age = 25
            //};



            ////Console.WriteLine(context.Entry(employee).State); //Detached

            ////employee.Name = "Khaled";

            //////context.Add(employee)
            //--> context.Employees.Add(employee);


            ////Console.WriteLine(context.Entry(employee).State); //Added

            //--> var Result = context.SaveChanges();

            ////Console.WriteLine(context.Entry(employee).State); //Unchanged

            ////employee.Name = "Omar";

            ////Console.WriteLine(context.Entry(employee).State); // Modified

            ////Console.WriteLine(Result);

            ////context.Employees.Add(employee);
            //--> context.SaveChanges();


            //Console.WriteLine(context.Entry(employee).State); // Detached

            //context.Entry(employee).State = EntityState.Added;

            //Console.WriteLine(context.Entry(employee).State); // Added

            //context.SaveChanges(); 
            #endregion

            #region Read - Select
            //var Result = context.Employees.Where(E => E.Id == 40).FirstOrDefault();
            //var Result = context.Employees.FirstOrDefault(E => E.Id == 40);
            //var Result = context.Employees.FirstOrDefault(E => E.Id == 40);

            ////var Result = context.Employees.Select(E => E.Name);

            //Console.WriteLine(context.Entry(Result).State); //Unchanged

            //Result.Name = "Ali";

            //Console.WriteLine(context.Entry(Result).State); // Modified


            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(Result?.Name);
            //Console.WriteLine(Result?.Id); 
            #endregion

            #region Update
            //var Result = context.Employees.FirstOrDefault(E => E.Id == 40);

            //Console.WriteLine(context.Entry(Result).State);

            //Result.Name = "Omar Mohamed";
            ////Console.WriteLine(context.Entry(Result).State);

            ////context.Update(Result);
            //Console.WriteLine(context.Entry(Result).State);

            //context.SaveChanges();
            //Console.WriteLine(context.Entry(Result).State); 
            #endregion

            #region Delete
            //var Result = context.Employees.FirstOrDefault(E => E.Id == 50);

            //Console.WriteLine(context.Entry(Result).State);// Unchanged

            //context.Employees.Remove(Result);
            //Console.WriteLine(context.Entry(Result).State);// Deleted

            //context.SaveChanges();
            //Console.WriteLine(context.Entry(Result).State); // Detached 
            #endregion
            #endregion

            //Employee employee = new Employee();
            //Department department = new Department();
            //department.Manager.

            using (var context = new AppDbContext())
            {
                // Create
                CreateEmployee(context, "John Doe", 50000, 30, "New York");
                CreateDepartment(context, "IT Department");

                // Read
                var employee = ReadEmployee(context, 1);
                var department = ReadDepartment(context, 100);

                // Update
                UpdateEmployee(context, 1, "John Smith", 55000, 31, "Los Angeles");
                UpdateDepartment(context, 100, "HR Department");

                // Delete
                DeleteEmployee(context, 1);
                DeleteDepartment(context, 100);

                // Relationships
                AssignEmployeeToDepartment(context, 2, 101);
                AssignManagerToDepartment(context, 3, 102);
            }
        }

        // Create operations
        static void CreateEmployee(AppDbContext context, string name, decimal salary, int age, string address)
        {
            var employee = new Employee
            {
                EmployeeName = name,
                Salary = salary,
                Age = age,
                Address = address
            };

            context.Employees.Add(employee);
            context.SaveChanges();
            Console.WriteLine($"Employee created: {employee.Id}");
        }

        static void CreateDepartment(AppDbContext context, string name)
        {
            var department = new Department
            {
                DeptName = name
            };

            context.Departments.Add(department);
            context.SaveChanges();
            Console.WriteLine($"Department created: {department.Id}");
        }

        // Read operations
        static Employee ReadEmployee(AppDbContext context, int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                Console.WriteLine($"Employee found: {employee.EmployeeName}");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
            return employee;
        }

        static Department ReadDepartment(AppDbContext context, int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                Console.WriteLine($"Department found: {department.DeptName}");
            }
            else
            {
                Console.WriteLine("Department not found");
            }
            return department;
        }

        // Update operations
        static void UpdateEmployee(AppDbContext context, int id, string name, decimal salary, int age, string address)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                employee.EmployeeName = name;
                employee.Salary = salary;
                employee.Age = age;
                employee.Address = address;
                context.SaveChanges();
                Console.WriteLine("Employee updated");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        static void UpdateDepartment(AppDbContext context, int id, string name)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                department.DeptName = name;
                context.SaveChanges();
                Console.WriteLine("Department updated");
            }
            else
            {
                Console.WriteLine("Department not found");
            }
        }

        // Delete operations
        static void DeleteEmployee(AppDbContext context, int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                Console.WriteLine("Employee deleted");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        static void DeleteDepartment(AppDbContext context, int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                Console.WriteLine("Department deleted");
            }
            else
            {
                Console.WriteLine("Department not found");
            }
        }

        // Relationship operations
        static void AssignEmployeeToDepartment(AppDbContext context, int employeeId, int departmentId)
        {
            var employee = context.Employees.Find(employeeId);
            var department = context.Departments.Find(departmentId);

            if (employee != null && department != null)
            {
                employee.WorkForId = departmentId;
                context.SaveChanges();
                Console.WriteLine("Employee assigned to department");
            }
            else
            {
                Console.WriteLine("Employee or Department not found");
            }
        }

        static void AssignManagerToDepartment(AppDbContext context, int employeeId, int departmentId)
        {
            var employee = context.Employees.Find(employeeId);
            var department = context.Departments.Find(departmentId);

            if (employee != null && department != null)
            {
                department.ManagerId = employeeId;
                context.SaveChanges();
                Console.WriteLine("Manager assigned to department");
            }
            else
            {
                Console.WriteLine("Employee or Department not found");
            }





        }

    }
}
