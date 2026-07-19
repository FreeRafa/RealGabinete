using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Models
{
    public class Exemplares
    {
        public int Id { get; set; }
        public string CodigoExemplar { get; set; } = string.Empty;
        public EstadoExemplar Estado { get; set; } = EstadoExemplar.Disponivel;

        // Chave estrangeira para o livro
        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;

        public int PrateleiraId { get; set; }
        public Prateleira? Prateleira { get; set; }

        // Propriedade de navegação para os empréstimos
        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    }

    public enum EstadoExemplar
    {
        Disponivel,
        Emprestado,
        Reservado,
        Danificado,
        Perdido
    }
}
