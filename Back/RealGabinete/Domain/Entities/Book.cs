using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public decimal Price { get; set; }


        public Author Author { get; set; } = null!;
        public int AuthorId { get; set; }

        public Publisher Publisher { get; set; } = null!;
        public int PublisherId { get; set; }

        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }


        public ICollection<Copy> Copies { get; set; } = new List<Copy>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        
    }
}
