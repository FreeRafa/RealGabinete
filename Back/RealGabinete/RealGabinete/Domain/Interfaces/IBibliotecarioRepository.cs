using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IBibliotecarioRepository
    {
        Task<List<Bibliotecario>> ObterTodosAsync();
        Task<Bibliotecario?> ObterPorIdAsync(int id);
        Task<Bibliotecario?> AdicionarAsync(Bibliotecario bibliotecario);
        Task<Bibliotecario?> AtualizarAsync(Bibliotecario bibliotecario);
        
    }
}
