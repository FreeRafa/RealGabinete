using RealGabinete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealGabinete.Domain.Interfaces
{
    public interface ISalaRepository
    {
        Task<List<Sala>> ObterTodosAsync();
        Task<Sala?> ObterPorIdAsync(int id);
        Task<Sala> AdicionarAsync(Sala sala);
        Task AtualizarAsync(Sala sala);
        Task RemoverAsync(int id);
    }
}
