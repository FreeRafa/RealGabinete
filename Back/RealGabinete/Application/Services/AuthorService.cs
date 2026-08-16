using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;


namespace RealGabinete.Application.Services
{
    public class AuthorService
    {
        private readonly IUnitOfWork _uow;

        public AuthorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _uow.Authors.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _uow.Authors.GetByIdAsync(id);
        }

        public async Task<Author> AddAsync(Author author)
        {
            await _uow.Authors.AddAsync(author);
            await _uow.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAsync(Author author)
        {
            await _uow.Authors.UpdateAsync(author);
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _uow.Authors.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}