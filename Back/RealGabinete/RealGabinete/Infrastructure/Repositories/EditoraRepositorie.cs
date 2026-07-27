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
    public class EditoraRepositorie : IEditoraRepository
    {
        private readonly RealGabineteContext _context;

        public EditoraRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Editora>> ObterTodosAsync()
        {
            return await _context.Editoras.ToListAsync();
        }

        public async Task<Editora?> ObterPorIdAsync(int id)
        {
            return await _context.Editoras.FindAsync(id);
        }

        public async Task<Editora?> AdicionarAsync(Editora editora)
        {
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();
            return editora;
        }

        public async Task<Editora?> AtualizarAsync(Editora editora)
        {
            _context.Editoras.Update(editora);
            await _context.SaveChangesAsync();
            return editora;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            if (editora == null)
                return false;
            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
