using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Prateleira
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;

        public int SalaId { get; set; } // Chave estrangeira para a sala
        public Sala Sala { get; set; } = null!; // Propriedade de navegação para a sala

        public ICollection<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
    }
}
