using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;


namespace RealGabinete.Infrastructure.Repositories
{
    public class FineRepository : IFineRepository
    {
        private readonly RealGabineteContext _context;

        public FineRepository(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Fine>> GetAllAsync()
        {
            return await _context.Fines.ToListAsync();
        }

        public async Task<Fine?> GetByIdAsync(int id)
        {
            return await _context.Fines.FindAsync(id);
        }

        public async Task<Fine> AddAsync(Fine fine)
        {
            await _context.Fines.AddAsync(fine);
            await _context.SaveChangesAsync();
            return fine;
        }

        public async Task UpdateAsync(Fine fine)
        {
            _context.Fines.Update(fine);
            await _context.SaveChangesAsync();
            
        }

    }
}
