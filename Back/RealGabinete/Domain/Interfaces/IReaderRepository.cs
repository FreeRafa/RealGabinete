using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;
namespace RealGabinete.Domain.Interfaces
{
    public interface IReaderRepository
    {
        Task<List<Reader>> GetAllAsync();
        Task<Reader?> GetByIdAsync(int id);
        Task<Reader> AddAsync(Reader reader);
        Task UpdateAsync(Reader reader);
        Task RemoveAsync(int id);
    }
}
