using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        public DateTime ReturnDate { get; set; } 

        public Copy Copy { get; set; } = null!;
        public int CopyId { get; set; }

        public Reader Reader { get; set; } = null!;
        public int ReaderId { get; set; }

        public Librarian Librarian { get; set; } = null!;
        public int LibrarianId { get; set; }

        public ICollection<Fine> Fines { get; set; } = new List<Fine>();
    }
}
