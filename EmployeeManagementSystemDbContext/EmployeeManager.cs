using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementSystem;

namespace EmployeeManagementSystemDbContext
{
    public static class EmployeeManager
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static Employee AddEmployee(Employee employee)
        {
            decimal initialWageRate = 0;
            employee.JoinDate = DateTime.Now;
            
            if (initialWageRate > 0)
            {
                employee.SetWageRate(initialWageRate);
            }
            //var employeeRole = db.EmployeeRoles.First();

            db.DbEmployees.Add(employee);
            db.SaveChanges();
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Add,
                Description = "Added Employee Details",
                EmpId = employee.EmpId

            };
            db.DbTransactions.Add(transaction);
            db.SaveChanges();

            return employee;
        }
        public static IEnumerable<Employee> GetAllEmployees(string emailAddress)
        {
            if (emailAddress == "jhon@gmail.com")
            {
                return db.DbEmployees;
            }
            else
            {
                return db.DbEmployees.Where(a => a.Email == emailAddress);
            }


        }
        public static IEnumerable<Transaction> GetAllTransactions(int empId)

        {
            return db.DbTransactions.Where(t => t.EmpId == empId)
                     .OrderByDescending(t => t.TransactionDate);
        }
        public static Employee GetEmployeeDetails(int empId)
        {
            //var employeeRole = db.EmployeeRoles !=  null? db.EmployeeRoles.FirstOrDefault() : null;

            var employee = db.DbEmployees.SingleOrDefault(m => m.EmpId == empId);
            //employee.EmployeeRole = employeeRole;

            return employee;
        }
        public static void EditEmployee(Employee updatedEmployee)

        {
            var oldEmployee = GetEmployeeDetails(updatedEmployee.EmpId);
            oldEmployee.WageRate = updatedEmployee.WageRate;
            oldEmployee.Department = updatedEmployee.Department;
            oldEmployee.Designation = updatedEmployee.Designation;
            oldEmployee.EManagerId = updatedEmployee.EManagerId;
            oldEmployee.JoinDate = updatedEmployee.JoinDate;
            //db.SaveChanges();
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Update,
                Description = "Updated Employee Details",
                EmpId = updatedEmployee.EmpId

            };
            db.DbTransactions.Add(transaction);
            db.SaveChanges();

        }
        public static void DeleteEmployee(int empId)
        {
            var employee = EmployeeManager.GetEmployeeDetails(empId);
            db.DbEmployees.Remove(employee);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Delete,
                Description = "Deleted Employee Details",
                EmpId = employee.EmpId

            };
            db.DbTransactions.Add(transaction);
            db.SaveChanges();
        }
        public static bool EmployeeExists(int id)
        {
            return db.DbEmployees.Any(e => e.EmpId == id);
        }
    }
}

