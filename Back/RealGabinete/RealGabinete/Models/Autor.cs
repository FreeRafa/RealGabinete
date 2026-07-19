using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UltimoNome { get; set; } = string.Empty;

        //Navegacão: um autor tem varios livros
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
