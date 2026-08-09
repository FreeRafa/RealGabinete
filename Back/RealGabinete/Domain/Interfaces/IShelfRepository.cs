using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IShelfRepository
    {
        Task<List<Shelf>> GetAllAsync();
        Task<Shelf?> GetByIdAsync(int id);
        Task<Shelf> AddAsync(Shelf shelf);
        Task UpdateAsync(Shelf shelf);
        Task RemoveAsync(int id);
    }
}
