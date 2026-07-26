using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IMultasRepository
    {
        Task<List<Multa>> ObterTodosAsync();
        Task<Multa?> ObterPorIdAsync(int id);
        Task<Multa?> AdicionarAsync(Multa multa);
        Task<Multa?> AtualizarAsync(Multa multa);
    }
}
