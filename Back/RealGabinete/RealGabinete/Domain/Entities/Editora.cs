using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Editora
    {
        public int Id { get; set; }
        public string NomeEditora { get; set; } = string.Empty;

        //Navegacão: uma editora tem varios livros
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
