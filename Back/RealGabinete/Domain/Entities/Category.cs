using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navegação: uma categoria tem vários livros
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
