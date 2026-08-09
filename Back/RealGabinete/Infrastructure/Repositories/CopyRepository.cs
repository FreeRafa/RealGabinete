using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        private readonly RealGabineteContext _context;

        public CopyRepository(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Copy>> GetAllAsync()
        {
            return await _context.Copies.ToListAsync();
        }

        public async Task<Copy?> GetByIdAsync(int id)
        {
            return await _context.Copies.FindAsync(id);
        }

        public async Task<Copy> AddAsync(Copy copy)
        {
            await _context.Copies.AddAsync(copy);
            await _context.SaveChangesAsync();
            return copy;
        }

        public async Task UpdateAsync(Copy copy)
        {
            _context.Copies.Update(copy);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id) {
            var copy = await _context.Copies.FindAsync(id);
            if (copy != null)
            {
                _context.Copies.Remove(copy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
