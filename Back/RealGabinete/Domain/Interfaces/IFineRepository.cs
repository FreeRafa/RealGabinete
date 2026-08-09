using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface IFineRepository
    {
        Task<List<Fine>> GetAllAsync();
        Task<Fine?> GetByIdAsync(int id);
        Task<Fine> AddAsync(Fine fine);
        Task UpdateAsync(Fine fine);
    }
}
