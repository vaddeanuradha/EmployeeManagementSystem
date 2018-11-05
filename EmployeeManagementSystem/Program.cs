using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Welcome to Employee Management System");
            Console.WriteLine("********************");
            while (true)
            {
                Employee employee = new Employee();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. AddEmployee ");
                Console.WriteLine("2.  UpadateEmployee");
                Console.WriteLine("3.  DeleteEmploye");
                Console.WriteLine("4.  Print all Employees");
                Console.WriteLine("Select an option");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        return;
                    case "1":

                        try
                        {
                            Console.WriteLine("enter Superwiser Id");
                            employee.SuperviserId = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter Employee Name");
                            employee.EmpName = Console.ReadLine();
                            Console.WriteLine("enter EmailAddress");
                            employee.Email = Console.ReadLine();


                            var typeOfDepartments =
                                Enum.GetNames(typeof(TypeOfDepartment));
                            for (var i = 0; i < typeOfDepartments.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}.  {typeOfDepartments[i]}");
                            }
                            Console.WriteLine("Select an Department type");
                            var typeOfDepartmentOption = Convert.ToInt32(Console.ReadLine());
                            employee.Department = (TypeOfDepartment)Enum.Parse(typeof(TypeOfDepartment),
                                 typeOfDepartments[typeOfDepartmentOption - 1]);
                            //employee.Department = TypeOfDepartment.IT;
                            var typeOfDesignations =
                            Enum.GetNames(typeof(TypeOfDesignation));
                            for (var i = 0; i < typeOfDesignations.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}.  {typeOfDesignations[i]}");
                            }

                            Console.WriteLine("Select an Designation type");
                            var typeOfDesignationOption = Convert.ToInt32(Console.ReadLine());
                            employee.Designation = (TypeOfDesignation)Enum.Parse(typeof(TypeOfDesignation),
                            typeOfDesignations[typeOfDesignationOption - 1]);

                            Console.WriteLine("enter contact Details");
                            employee.Contact = int.Parse(Console.ReadLine());

                            Console.WriteLine("enter WageRate");
                            var setInitialWageRate = Convert.ToDecimal(Console.ReadLine());
                            employee.SetWageRate(setInitialWageRate);
                            employee.Address = employee.Email;
                            //employee.Designation = TypeOfDesignation;
                            EmployeeManager.AddEmployee(employee);
                        }
                        catch (FormatException fx)
                        {
                            Console.WriteLine($"Error : {fx.Message}");
                        }
                        catch( Exception ex)
                        {
                            Console.WriteLine("Something went Wrong");
                        }
                        break;
                    case "2":
                        PrintAllEmployees();
                        EmployeeManager.UpdateEmployee(employee);
                        PrintAllEmployees();
                        break;
                    case "3":
                        PrintAllEmployees();
                        EmployeeManager.DeleteEmployee(employee);
                        PrintAllEmployees();
                        break;
                    case "4":
                        PrintAllEmployees();
                        break;
                    default:
                        break;
                }
            }

            
        }

        private static void PrintAllEmployees()
        {
            var employees = EmployeeManager.GetAllEmployees();
            foreach (var empt in employees)
            {
                Console.WriteLine($"EId: {empt.EmpId},EName:{empt.EmpName},Edesignation:{empt.Designation}, EWageRate:{empt.WageRate}");
            }
        }
    }
}
