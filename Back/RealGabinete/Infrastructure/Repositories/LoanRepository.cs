using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly RealGabineteContext _context;

        public LoanRepository(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        
    }
}
