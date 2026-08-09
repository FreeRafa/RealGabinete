using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public bool Paid { get; set; } = false;
        public DateTime? PaymentDate { get; set; } 

        public Loan Loan { get; set; } = null!;
        public int LoanId { get; set; }

    }
}
