using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;
namespace RealGabinete.Application.Services
{
    public class ShelfService
    {
        private readonly IUnitOfWork _uow;

        public ShelfService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Shelf>> GetAllAsync()
        {
            return await _uow.Shelves.GetAllAsync();
        }

        public async Task<Shelf?> GetByIdAsync(int id)
        {
            return await _uow.Shelves.GetByIdAsync(id);
        }

        public async Task<Shelf> AddAsync(Shelf shelf)
        {
            await _uow.Shelves.AddAsync(shelf);
            await _uow.SaveChangesAsync();
            return shelf;
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            await _uow.Shelves.UpdateAsync(shelf);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.Shelves.RemoveAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
