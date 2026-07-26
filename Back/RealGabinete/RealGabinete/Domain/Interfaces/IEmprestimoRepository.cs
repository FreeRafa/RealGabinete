using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;
{
    
}

namespace RealGabinete.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> ObterTodosAsync();
        Task<Emprestimo?> ObterPorIdAsync(int id);
        Task<Emprestimo?> AdicionarAsync(Emprestimo emprestimo);
        Task<Emprestimo?> AtualizarAsync(Emprestimo emprestimo);
        
    }
}
