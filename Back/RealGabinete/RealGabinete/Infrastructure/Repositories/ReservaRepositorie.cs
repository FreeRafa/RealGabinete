using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;
using RealGabinete.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;

namespace RealGabinete.Infrastructure.Repositories
{
    public class ReservaRepositorie : IReservaRepository
    {
        private readonly RealGabineteContext _context;

        public ReservaRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> ObterTodosAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> ObterPorIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reserva> AdicionarAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<Reserva> AtualizarAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

    }
}
