using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NameCategoria { get; set; } = string.Empty;

        //Navegacão: uma categoria tem varios livros
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
