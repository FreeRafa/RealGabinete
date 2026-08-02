using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> ObterTodosAsync();
        Task<Reserva?> ObterPorIdAsync(int id);
        Task<Reserva> AdicionarAsync(Reserva reserva);
        Task<Reserva> AtualizarAsync(Reserva reserva);
        
    }
}
