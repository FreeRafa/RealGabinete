using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IEditoraRepository
    {
        Task<List<Editora>> ObterTodosAsync();
        Task<Editora?> ObterPorIdAsync(int id);
        Task<Editora?> AdicionarAsync(Editora editora);
        Task AtualizarAsync(Editora editora);
        Task RemoverAsync(int id);
    }
}
