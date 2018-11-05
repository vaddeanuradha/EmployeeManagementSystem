using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem
{
    enum TransactionType
    {
        Add,
        Update,
        Delete
    }
    class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionType TypeOfTransaction { get; set; }
        public string  Description { get; set; }
        


    }
}
