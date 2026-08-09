using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface ICopyRepository
    {
        Task<List<Copy>> GetAllAsync();
        Task<Copy?> GetByIdAsync(int id);
        Task<Copy> AddAsync(Copy copy);
        Task UpdateAsync(Copy copy);
        Task RemoveAsync(int id);

    }
}
