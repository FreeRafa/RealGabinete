using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Enums;

namespace RealGabinete.Domain.Entities
{
    public class Copy
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public CopyStatus Status { get; set; } = CopyStatus.Available;

        public Book Book { get; set; } = null!;
        public int BookId { get; set; }

        public Shelf? Shelf { get; set; }
        public int? ShelfId { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    }
}
