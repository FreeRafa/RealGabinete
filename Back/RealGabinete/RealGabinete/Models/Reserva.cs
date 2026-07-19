using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public StatusReserva Status { get; set; } = StatusReserva.Pendente;

        //Chaves estrangeiras
        public int LeitorId { get; set; }
        public Leitor Leitor { get; set; } = null!;

        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;

        
    }

    public enum StatusReserva
    {
        Pendente,
        Confirmada,
        Cancelada
    }
}
