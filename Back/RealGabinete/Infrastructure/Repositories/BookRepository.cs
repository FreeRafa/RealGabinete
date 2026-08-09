using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Entities;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealGabinete.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RealGabineteContext _context;

        public BookRepository(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}