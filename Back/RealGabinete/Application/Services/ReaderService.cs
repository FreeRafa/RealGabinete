using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;

namespace RealGabinete.Application.Services
{
    public class ReaderService
    {
        private readonly IUnitOfWork _uow;
        public ReaderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Reader>> GetAllAsync()
        {
            return await _uow.Readers.GetAllAsync();
        }

        public async Task<Reader?> GetByIdAsync(int id)
        {
            return await _uow.Readers.GetByIdAsync(id);
        }

        public async Task<Reader> AddAsync(Reader reader)
        {
            await _uow.Readers.AddAsync(reader);
            await _uow.SaveChangesAsync();
            return reader;
        }

        public async Task UpdateAsync(Reader reader)
        {
            await _uow.Readers.UpdateAsync(reader);
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _uow.Readers.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
