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
    public class LivrosRepositorie : ILivrosRepository
    {
        private readonly RealGabineteContext _context;
        public LivrosRepositorie(RealGabineteContext context)
        {
            _context = context;
        }
        public async Task<List<Livro>> ObterTodosAsync()
        {
            return await _context.Livros.ToListAsync();
        }
        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }
        public async Task<Livro?> AdicionarAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
        public async Task AtualizarAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
            
        }
        public async Task RemoverAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }

        }
    }
}
