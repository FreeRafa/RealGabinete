using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;

        public Room Room { get; set; } = null!;
        public int RoomId { get; set; }

        public ICollection<Copy> Copies { get; set; } = new List<Copy>();

    }
}
