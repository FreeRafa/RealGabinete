using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Multa
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; } = DateTime.Now;
        public bool Paga { get; set; } = false;
        public DateTime? DataPagamento { get; set; }

        //Chave estrangeira
        public int EmprestimoId { get; set; }
        public Emprestimo Emprestimo { get; set; } = null!;
    }
}
