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
    public  class LeitoresRepositorie : ILeitoresRepository
    {
        private readonly RealGabineteContext _context;

        public LeitoresRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Leitor>> ObterTodosAsync()
        {
            return await _context.Leitores.ToListAsync();
        }

        public async Task<Leitor?> ObterPorIdAsync(int id)
        {
            return await _context.Leitores.FindAsync(id);
        }

        public async Task<Leitor> AdicionarAsync(Leitor leitor)
        {
            _context.Leitores.Add(leitor);
            await _context.SaveChangesAsync();
            return leitor;
        }

        public async Task AtualizarAsync(Leitor leitor)
        {
            _context.Leitores.Update(leitor);
            await _context.SaveChangesAsync();
            
        }

        public async Task RemoverAsync(int Id)
        {
            var leitor = await _context.Leitores.FindAsync(Id);
            if (leitor == null)
                return;
            _context.Leitores.Remove(leitor);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
