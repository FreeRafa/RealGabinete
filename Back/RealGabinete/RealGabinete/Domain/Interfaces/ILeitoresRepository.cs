using RealGabinete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Interfaces
{
    public interface ILeitoresRepository
    {
        Task<List<Leitor>> ObterTodosAsync();
        Task<Leitor?> ObterPorIdAsync(int id);
        Task<Leitor?> AdicionarAsync(Leitor leitor);
        Task<Leitor?> AtualizarAsync(Leitor leitor);
        Task<bool> RemoverAsync(int id);
    }
}
