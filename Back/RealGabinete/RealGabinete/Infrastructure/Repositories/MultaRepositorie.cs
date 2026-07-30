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
    public class MultaRepositorie : IMultasRepository
    {
        private readonly RealGabineteContext _context;

        public MultaRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Multa>> ObterTodosAsync()
        {
            return await _context.Multas.ToListAsync();
        }
        public async Task<Multa?> ObterPorIdAsync(int id)
        {
            return await _context.Multas.FindAsync(id);
        }
        public async Task<Multa?> AdicionarAsync(Multa multa)
        {
            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();
            return multa;
        }
        public async Task<Multa?> AtualizarAsync(Multa multa)
        {
            _context.Multas.Update(multa);
            await _context.SaveChangesAsync();
            return multa;
        }
                
    } 
}
