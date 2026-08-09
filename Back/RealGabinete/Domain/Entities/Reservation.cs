using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Enums;

namespace RealGabinete.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateOnly ReservationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public Reader Reader { get; set; } = null!;
        public int ReaderId { get; set; }

        public Book Book { get; set; } = null!;
        public int BookId { get; set; }
    }
}
