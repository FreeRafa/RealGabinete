using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;


namespace RealGabinete.Application.Services
{
    public class FineService
    {
        private readonly IUnitOfWork _uow;

        public FineService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Fine>> GetAllAsync()
        {
            return await _uow.Fines.GetAllAsync();
        }

        public async Task<Fine?> GetByIdAsync(int id)
        {
            return await _uow.Fines.GetByIdAsync(id);
        }

        public async Task<Fine> AddAsync(Fine fine)
        {
            await _uow.Fines.AddAsync(fine);
            await _uow.SaveChangesAsync();
            return fine;
        }

        public async Task UpdateAsync(Fine fine)
        {
            await _uow.Fines.UpdateAsync(fine);
            await _uow.SaveChangesAsync();
        }
    }
}
