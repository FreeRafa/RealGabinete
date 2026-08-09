using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Domain.Interfaces
{
    public interface ILibrarianRepository
    {
        Task<List<Librarian>> GetAllAsync();
        Task<Librarian?> GetByIdAsync(int id);
        Task<Librarian> AddAsync(Librarian librarian);
        Task UpdateAsync(Librarian librarian);
        Task DeactivateAsync(int id);
    }
}
