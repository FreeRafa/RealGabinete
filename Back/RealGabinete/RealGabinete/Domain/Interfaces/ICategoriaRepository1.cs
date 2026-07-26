using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObterTodosAsync();
        Task<Categoria?> ObterPorIdAsync(int id);
        Task<Categoria?> AdicionarAsync(Categoria categoria);
        Task<Categoria?> AtualizarAsync(Categoria categoria);
        Task<bool> RemoverAsync(int id);
    }
}
