using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IPrateleiraRepository
    {
        Task<List<Prateleira>> ObterTodosAsync();
        Task<Prateleira?> ObterPorIdAsync(int id);
        Task<Prateleira?> AdicionarAsync(Prateleira prateleira);
        Task<Prateleira?> AtualizarAsync(Prateleira prateleira);
        Task<bool> RemoverAsync(int id);
    }
}
