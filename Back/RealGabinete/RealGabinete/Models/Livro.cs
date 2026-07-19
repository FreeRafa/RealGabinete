using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }

        //chaves estrangeiras
        public int AutorId { get; set; }    
        public Autor Autor { get; set; } = null!;

        public int EditoraId { get; set; }
        public Editora Editora { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        //Navegacão: um livro tem varios exemplares
        public ICollection<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

    }
}
