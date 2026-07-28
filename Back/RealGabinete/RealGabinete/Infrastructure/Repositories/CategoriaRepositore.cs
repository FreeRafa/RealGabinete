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
    public class CategoriaRepositore : ICategoriaRepository
    {
        private readonly RealGabineteContext _context;

        public CategoriaRepositore(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ObterTodosAsync() 
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> ObterPorIdAsync(int id) 
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> AdicionarAsync(Categoria categoria) 
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return false;

            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
