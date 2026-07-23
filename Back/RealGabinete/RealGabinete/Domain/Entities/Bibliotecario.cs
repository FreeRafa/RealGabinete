using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Entities
{
    public class Bibliotecario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string UltimoNome { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public bool Ativo { get; set; } = true;

        //Navegacão: um bibliotecario tem varias salas
        public ICollection<Emprestimo> Emprestimo { get; set; } = new List<Emprestimo>();

    }
}
