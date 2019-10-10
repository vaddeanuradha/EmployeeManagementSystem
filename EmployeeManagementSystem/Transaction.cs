using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem
{
   public enum TransactionType
   {
        Add,
        Update,
        Delete
   }
   public class Transaction
   {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionType TypeOfTransaction { get; set; }
        public string  Description { get; set; }
        [ForeignKey("Employee")]
        public int EmpId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
