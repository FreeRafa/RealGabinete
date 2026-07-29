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
    public class BibliotecarioRepositorie : IBibliotecarioRepository
    {
        private readonly RealGabineteContext _context;

        public BibliotecarioRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Bibliotecario>> ObterTodosAsync()
        {
            return await _context.Bibliotecarios.ToListAsync();
        }

        public async Task<Bibliotecario?> ObterPorIdAsync(int id)
        {
            return await _context.Bibliotecarios.FindAsync(id);
        }

        public async Task<Bibliotecario?> AdicionarAsync(Bibliotecario bibliotecario)
        {
            _context.Bibliotecarios.Add(bibliotecario);
            await _context.SaveChangesAsync();
            return bibliotecario;
        }

        public async Task<Bibliotecario?> AtualizarAsync(Bibliotecario bibliotecario)
        {
            _context.Bibliotecarios.Update(bibliotecario);
            await _context.SaveChangesAsync();
            return bibliotecario;
        }

       
    }
}
