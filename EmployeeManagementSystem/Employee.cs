using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem
{
    public enum TypeOfDepartment
    {
        Finance,
        Sales,
        Adminstration,
        IT
    }
   
     public enum TypeOfDesignation
      {
        Manager,
        SrManager,
        SysEngineer,
        JrSysEngineer

      }
    public class Employee
    {

        #region
        public int EmpId { get; set; }
        public int EManagerId { get; set; }
        public string Email { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public decimal WageRate { get; set; }
        public int Contact { get; set; }
        public TypeOfDepartment Department { get; set; }
        public DateTime JoinDate { get; set; }
        public TypeOfDesignation Designation { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }




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
