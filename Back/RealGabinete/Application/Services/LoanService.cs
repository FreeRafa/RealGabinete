using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;
using System.Threading.Tasks;

namespace RealGabinete.Application.Services
{
    public class LoanService
    {
        private readonly IUnitOfWork _uow;

        public LoanService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _uow.Loans.GetAllAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _uow.Loans.GetByIdAsync(id);
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            await _uow.Loans.AddAsync(loan);
            await _uow.SaveChangesAsync();
            return loan;
        }

        public async Task UpdateAsync(Loan loan)
        {
            await _uow.Loans.UpdateAsync(loan);
            await _uow.SaveChangesAsync();
        }

        
    }
}
