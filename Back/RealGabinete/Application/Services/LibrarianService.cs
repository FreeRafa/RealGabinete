using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;

namespace RealGabinete.Application.Services
{
    public class LibrarianService
    {
        private readonly IUnitOfWork _uow;

        public LibrarianService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Librarian>> GetAllAsync()
        {
            return await _uow.Librarians.GetAllAsync();
        }

        public async Task<Librarian?> GetByIdAsync(int id)
        {
            return await _uow.Librarians.GetByIdAsync(id);
        }

        public async Task<Librarian> AddAsync(Librarian librarian)
        {
            await _uow.Librarians.AddAsync(librarian);
            await _uow.SaveChangesAsync();
            return librarian;
        }

        public async Task UpdateAsync(Librarian librarian)
        {
            await _uow.Librarians.UpdateAsync(librarian);
            await _uow.SaveChangesAsync();
        }

        public async Task DeactivateAsync(int id)
        {
            await _uow.Librarians.DeactivateAsync(id);
            await _uow.SaveChangesAsync();
        }

    }
}
