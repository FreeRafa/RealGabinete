using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Application.Services
{
    public class PublisherService
    {
        private readonly IUnitOfWork _uow;

        public PublisherService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _uow.Publishers.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _uow.Publishers.GetByIdAsync(id);
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            await _uow.Publishers.AddAsync(publisher);
            await _uow.SaveChangesAsync();
            return publisher;
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            await _uow.Publishers.UpdateAsync(publisher);
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _uow.Publishers.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
