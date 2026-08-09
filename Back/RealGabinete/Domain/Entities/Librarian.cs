using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Librarian
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>(); 
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public bool Active { get; set; } = true;

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
