using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem
{
  public static class  EmployeeManager
    {
        private static readonly EmployeeModel db = new EmployeeModel();
       
         public static Employee AddEmployee(Employee employee)
         {
            decimal initialWageRate = 0;
            employee.JoinDate = DateTime.Now;

            if (initialWageRate>0)
            {
                employee.SetWageRate(initialWageRate);
            }
           
            db.Employees.Add(employee);
            db.SaveChanges();
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Add,
                Description = "Added Employee Details",
                EmpId = employee.EmpId 

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
           
            return employee;
          }
        public static Employee UpdateEmployee(int empId)
        {

            //var empId = Convert.ToInt32(Console.ReadLine());
            //var employeesList = EmployeeManager.GetAllEmployees();
            //var numOfEmployees = employees.Count;
            var employee = new Employee();
            foreach (var emp in db.Employees)
            {
                    if (empId == emp.EmpId)
                    {
                         var appraisal = Convert.ToDecimal(Console.ReadLine());
                         employee.UpdateWageRate(emp, appraisal);
                         break;  
                                        
                    }
                    
            }
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Update,
                Description = "Updated Employee Details",
                EmpId = empId

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return employee;

        }
        //public static Employee DeleteEmployee(int empId)
        //{
        //    //var empId = Convert.ToInt32(Console.ReadLine());
        //    var employee = new Employee();
        //        foreach (var emp in db.Employees.ToList())
        //        {
        //            if (empId == emp.EmpId)
        //            {

        //                 db.Employees.Remove(emp);
        //                 break;
        //            }
        //        }
        //    var transaction = new Transaction
        //    {
        //        TransactionDate = DateTime.Now,
        //        TypeOfTransaction = TransactionType.Delete,
        //        Description = "Deleted Employee Details",
        //        EmpId = empId

        //    };
        //    db.Transactions.Add(transaction);
        //    db.SaveChanges();
        //    return employee;
        //}
        public static IEnumerable<Employee> GetAllEmployees(string emailAddress)
        {
            return db.Employees.Where(a=> a.Email == emailAddress);
        }
        public static IEnumerable<Transaction>GetAllTransactions(int empId)

        {
            return db.Transactions.Where(t => t.EmpId == empId)
                     .OrderByDescending(t => t.TransactionDate);
        }
        public static Employee GetEmployeeDetails(int empId)
        {
            return  db.Employees.SingleOrDefault(m => m.EmpId == empId);
        }
        //private static void PrintAllEmployees()
        //{
        //    var employees = EmployeeManager.GetAllEmployees();
        //    foreach (var empt in employees)
        //    {
        //        Console.WriteLine($"EId: {empt.EmpId},EName:{empt.EmpName},Edesignation:{empt.Designation}, EWageRate:{empt.WageRate}");
        //    }
        //}
        public static void EditEmployee(Employee updatedEmployee)

        {
            var oldEmployee = GetEmployeeDetails(updatedEmployee.EmpId);
            oldEmployee.WageRate = updatedEmployee.WageRate;
            oldEmployee.Department = updatedEmployee.Department;
            oldEmployee.Designation = updatedEmployee.Designation;
            oldEmployee.SuperviserId = updatedEmployee.SuperviserId;
            oldEmployee.JoinDate = updatedEmployee.JoinDate;
            db.Update(oldEmployee);
            db.SaveChanges();
        }
        public static void DeleteEmployee(int empId)
        {
            var employee = EmployeeManager.GetEmployeeDetails(empId);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
        public static bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmpId == id);
        }
    }

}  

