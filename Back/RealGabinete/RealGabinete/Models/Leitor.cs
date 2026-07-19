using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UltimoNome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        //Navegacão: um leitor tem varios emprestimos
        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
