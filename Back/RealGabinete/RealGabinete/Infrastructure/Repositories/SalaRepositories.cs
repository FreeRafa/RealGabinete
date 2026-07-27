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
    public class SalaRepositories : ISalaRepository
    {
        private readonly RealGabineteContext _context;

        public SalaRepositories(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Sala>> ObterTodosAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala?> ObterPorIdAsync(int id)
        {
            return await _context.Salas.FindAsync(id);
        }

        public async Task<Sala> AdicionarAsync(Sala sala)
        {
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task AtualizarAsync(Sala sala)
        {
            _context.Entry(sala).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                await _context.SaveChangesAsync();
            }
        }

    }
}
