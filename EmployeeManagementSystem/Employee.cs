using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem
{
    enum TypeOfDepartment
    {
        Finance,
        Sales,
        Adminstration,
        IT
    }
   
      enum TypeOfDesignation
      {
        Manager,
        SrManager,
        SysEngineer,
        JrSysEngineer

      }
    class Employee
    {
        
        #region
        public int EmpId { get; private set; }
        public int SuperviserId { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal WageRate { get; private set; }
        public int Contact { get; set; }
        public TypeOfDepartment Department { get; set; }
        public DateTime JoinDate { get;  }
        public TypeOfDesignation Designation { get; set; }
        #endregion
        #region
        public Employee()
        {
            
            JoinDate = DateTime.Now;
            //WageRate = this.WageRate;
            //SuperviserId = this.SuperviserId;
            //EmpName = this.EmpName;
            //Address = this.Address;
            //Email = this.Email;
            //Contact = this.Contact;
            //Department = this.Department;
            //Designation = this.Designation;
            
        }
        #endregion
        public void SetWageRate( decimal wageRate)
        {
            WageRate += wageRate;
        }
        public void UpdateWageRate(Employee employee, decimal appraisal)
        {
            employee.WageRate = employee.WageRate + appraisal;
        }
        

    }
}
