using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly RealGabineteContext _context;

        public ShelfRepository(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Shelf>> GetAllAsync()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<Shelf?> GetByIdAsync(int id)
        {
            return await _context.Shelves.FindAsync(id);
        }

        public async Task<Shelf> AddAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            await _context.SaveChangesAsync();
            return shelf;
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelves.Remove(shelf);
                await _context.SaveChangesAsync();
            }
        }
    }
}
