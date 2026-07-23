using RealGabinete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Interfaces
{
    internal interface ISalaRepository
    {
        Task<List<Sala>> ObterTodosAsync();
        Task<Sala?> ObterPorIdAsync(int id);
        Task<Sala?> AdicionarAsync(Sala sala);
        Task AtualizarAsync(Sala sala);
        Task RemoverAsync(int id);
    }
}
