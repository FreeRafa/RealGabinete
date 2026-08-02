using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface ILivrosRepository
    {
        Task<List<Livro>> ObterTodosAsync();
        Task<Livro?> ObterPorIdAsync(int id);
        Task<Livro> AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task RemoverAsync(int id);
    }
}
