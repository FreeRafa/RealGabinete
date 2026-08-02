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
        Task<Leitor> AdicionarAsync(Leitor leitor);
        Task AtualizarAsync(Leitor leitor);
        Task RemoverAsync(int id);
    }
}
