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
    public class ExemplaresRepositorie : IExemplaresRepository
    {
        private readonly RealGabineteContext _context;

        public ExemplaresRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Exemplar>> ObterTodosAsync()
        {
            return await _context.Exemplares.ToListAsync();
        }

        public async Task<Exemplar?> ObterPorIdAsync(int id)
        {
            return await _context.Exemplares.FindAsync(id);
        }

        public async Task<Exemplar?> AdicionarAsync(Exemplar exemplar)
        {
            _context.Exemplares.Add(exemplar);
            await _context.SaveChangesAsync();
            return exemplar;
        }

        public async Task AtualizarAsync(Exemplar exemplar)
        {
            _context.Exemplares.Update(exemplar);
            await _context.SaveChangesAsync();

        }

        public async Task RemoverAsync(int Id)
        {
            var exemplar = await _context.Exemplares.FindAsync(Id);
            if (exemplar != null)
            {
                _context.Exemplares.Remove(exemplar);
                await _context.SaveChangesAsync();
            }
        }
    }
}
        
