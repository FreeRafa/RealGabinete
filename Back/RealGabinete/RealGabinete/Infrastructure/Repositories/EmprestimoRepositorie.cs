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
    public class EmprestimoRepositorie : IEmprestimoRepository
    {
        private readonly RealGabineteContext _context;

        public EmprestimoRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Emprestimo>> ObterTodosAsync()
        {
            return await _context.Emprestimos.ToListAsync();
        }

        public async Task<Emprestimo?> ObterPorIdAsync(int id)
        {
            return await _context.Emprestimos.FindAsync(id);
        }

        public async Task<Emprestimo> AdicionarAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<Emprestimo> AtualizarAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();

            return emprestimo;
        }


    }
}
