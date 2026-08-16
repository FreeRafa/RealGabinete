using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Application.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _uow.Categories.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _uow.Categories.GetByIdAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _uow.Categories.AddAsync(category);
            await _uow.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            await _uow.Categories.UpdateAsync(category);
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _uow.Categories.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
