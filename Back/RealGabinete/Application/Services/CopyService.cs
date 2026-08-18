using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;

namespace RealGabinete.Application.Services
{
    public class CopyService
    {
        private readonly IUnitOfWork _uow;

        public CopyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Copy>> GetAllAsync()
        {
            return await _uow.Copies.GetAllAsync();
        }

        public async Task<Copy?> GetByIdAsync(int id)
        {
            return await _uow.Copies.GetByIdAsync(id);
        }

        public async Task<Copy> AddAsync(Copy copy)
        {
            await _uow.Copies.AddAsync(copy);
            await _uow.SaveChangesAsync();
            return copy;
        }

        public async Task RemoveAsync(int id) 
        {
            await _uow.Copies.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(Copy copy)
        {
            await _uow.Copies.UpdateAsync(copy);
            await _uow.SaveChangesAsync();
        } 
    }
}
