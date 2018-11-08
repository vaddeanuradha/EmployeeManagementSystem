using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem
{
   static class  EmployeeManager
    {
        private static readonly EmployeeModel db = new EmployeeModel();
       
         public static Employee AddEmployee(Employee employee)
         {
            decimal initialWageRate = 0;
            if (initialWageRate>0)
            {
                employee.SetWageRate(initialWageRate);
            }
            Console.WriteLine("Adding employee");
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
        public static Employee UpdateEmployee(Employee employee)
        {
            Console.WriteLine("Which Employee do you want to Update");
            Console.WriteLine("Enter Employee Id to Update");
            var empId = Convert.ToInt32(Console.ReadLine());
            //var employeesList = EmployeeManager.GetAllEmployees();
            //var numOfEmployees = employees.Count;
           
            foreach (var emp in db.Employees)
            {
                
                    if (empId == emp.EmpId)
                    {
                        Console.WriteLine("Updating employee");
                        Console.WriteLine("how much amount do you want" +
                                            " to increase WageRate for this Employee");
                        var appraisal = Convert.ToDecimal(Console.ReadLine());
                        
                         employee.UpdateWageRate(emp, appraisal);


                        //Console.WriteLine($"EId: {emp.EmpId}, EName: {emp.EmpName},Edesignation:{emp.Designation},EWageRate:{emp.WageRate}");

                       
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

            //var employees1 = GetAllEmployees();
            //foreach (var empt in employees1)
            //{
            //    Console.WriteLine($"EId: {empt.EmpId},EName:{empt.EmpName},Edesignation:{empt.Designation}, EWageRate:{empt.WageRate}");
            //}
            //db.SaveChanges();
            return employee;

        }
        public static Employee DeleteEmployee(Employee employee)
        {

            Console.WriteLine("Which Employee do you want to Delete");
            Console.WriteLine("Enter Employee Id to Delete");
            var empId = Convert.ToInt32(Console.ReadLine());
            //var employeesList = EmployeeManager.GetAllEmployees();
            //var numOfEmployees = employees.Count;


                foreach (var emp in db.Employees.ToList())
                {
                    if (empId == emp.EmpId)
                    {

                         db.Employees.Remove(emp);
                       
                    }
                }
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Delete,
                Description = "Deleted Employee Details",
                EmpId = empId

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();

            //db.SaveChanges();
            return employee;
        }
        public static IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees;
        }
        public static IEnumerable<Transaction>GetAllTransactions(int empId)

        {
            return db.Transactions.Where(t => t.EmpId == empId)
                     .OrderByDescending(t => t.TransactionDate);
        }

    }

}  

