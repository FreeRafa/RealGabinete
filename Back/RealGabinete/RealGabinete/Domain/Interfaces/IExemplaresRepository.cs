using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IExemplaresRepository
    {
        Task<List<Exemplar>> ObterTodosAsync();
        Task<Exemplar?> ObterPorIdAsync(int id);
        Task<Exemplar?> AdicionarAsync(Exemplar exemplar);
        Task AtualizarAsync(Exemplar exemplar);
        Task RemoverAsync(int id);
    }
}
