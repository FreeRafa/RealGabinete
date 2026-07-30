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
    public class PrateleiraRepositorie : IPrateleiraRepository
    {
        private readonly RealGabineteContext _context;

        public PrateleiraRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Prateleira>> ObterTodosAsync()
        {
            return await _context.Prateleiras.ToListAsync();
        }

        public async Task<Prateleira?> ObterPorIdAsync(int id)
        {
            return await _context.Prateleiras.FindAsync(id);
        }

        public async Task<Prateleira?> AdicionarAsync(Prateleira prateleira)
        {
            _context.Prateleiras.Add(prateleira);
            await _context.SaveChangesAsync();
            return prateleira;
        }
                
        public async Task AtualizarAsync(Prateleira prateleira)
        {
            _context.Prateleiras.Update(prateleira);
            await _context.SaveChangesAsync();
            
        }

        public async Task RemoverAsync(int id)
        {
            var prateleira = await _context.Prateleiras.FindAsync(id);
            if (prateleira == null)
                return;

            _context.Prateleiras.Remove(prateleira);
            await _context.SaveChangesAsync();
            return;
        }


    }
}
