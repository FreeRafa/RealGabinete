using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly RealGabineteContext _context;
        public LibrarianRepository(RealGabineteContext context)
        {
            _context = context;
        }
        public async Task<List<Librarian>> GetAllAsync()
        {
            return await _context.Librarians.ToListAsync();
        }
        public async Task<Librarian?> GetByIdAsync(int id)
        {
            return await _context.Librarians.FindAsync(id);
        }
        public async Task<Librarian> AddAsync(Librarian librarian)
        {
            await _context.Librarians.AddAsync(librarian);
            await _context.SaveChangesAsync();
            return librarian;
        }
        public async Task UpdateAsync(Librarian librarian)
        {
            _context.Librarians.Update(librarian);
            await _context.SaveChangesAsync();
        }
        public async Task DeactivateAsync(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian != null)
            {
                librarian.Active = false; 
                _context.Librarians.Update(librarian);
                await _context.SaveChangesAsync();
            }
        }
    }
}
