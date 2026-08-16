using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealGabineteContext _context;

        public AuthorRepository (RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync() 
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id) 
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> AddAsync(Author author) 
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAsync(Author author) 
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id) 
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null) 
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
