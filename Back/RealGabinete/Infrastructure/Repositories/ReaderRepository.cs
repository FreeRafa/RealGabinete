using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly RealGabineteContext _context;
        
        public ReaderRepository(RealGabineteContext context)
        {
            _context = context;
        }
        
        public async Task<List<Reader>> GetAllAsync()
        {
            return await _context.Readers.ToListAsync();
        }
        
        public async Task<Reader?> GetByIdAsync(int id)
        {
            return await _context.Readers.FindAsync(id);
        }
        
        public async Task<Reader> AddAsync(Reader reader)
        {
            await _context.Readers.AddAsync(reader);
            await _context.SaveChangesAsync();
            return reader;
        }
        
        public async Task UpdateAsync(Reader reader)
        {
            _context.Readers.Update(reader);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveAsync(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
