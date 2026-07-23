using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public string NomeSala { get; set; } = string.Empty;

        //Navegacão: uma sala tem varias prateleiras
        public ICollection<Prateleira> Prateleiras { get; set; } = new List<Prateleira>();
    }
}
