using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RealGabineteContext _context;

        public CategoryRepository (RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync() 
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id) 
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> AddAsync(Category category) 
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Category category) 
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id) 
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null) 
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
