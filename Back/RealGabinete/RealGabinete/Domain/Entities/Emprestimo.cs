using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; } 

        //Chave estrangeira
        public int ExemplarId { get; set; }
        public Exemplar Exemplar { get; set; } = null!;

        public int LeitorId { get; set; }
        public Leitor Leitor { get; set; } = null!;

        public int BibliotecarioId { get; set; }
        public Bibliotecario Bibliotecario { get; set; } = null!;

        public ICollection<Multa> Multas { get; set; } = new List<Multa>();
    }
}
