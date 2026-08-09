using System;
using System.Threading.Tasks;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;

namespace RealGabinete.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealGabineteContext _context;

        public IAuthorRepository Authors { get; }
        public ICategoryRepository Categories { get; }
        public IPublisherRepository Publishers { get; }
        public IRoomRepository Rooms { get; }
        public IShelfRepository Shelves { get; }
        public IReaderRepository Readers { get; }
        public IBookRepository Books { get; }
        public ICopyRepository Copies { get; }
        public ILibrarianRepository Librarians { get; }
        public ILoanRepository Loans { get; }
        public IReservationRepository Reservations { get; }
        public IFineRepository Fines { get; }

        public UnitOfWork(RealGabineteContext context)
        {
            _context = context;

            Authors = new AuthorRepository(_context);
            Categories = new CategoryRepository(_context);
            Publishers = new PublisherRepository(_context);
            Rooms = new RoomRepository(_context);
            Shelves = new ShelfRepository(_context);
            Readers = new ReaderRepository(_context);
            Books = new BookRepository(_context);
            Copies = new CopyRepository(_context);
            Librarians = new LibrarianRepository(_context);
            Loans = new LoanRepository(_context);
            Reservations = new ReservationRepository(_context);
            Fines = new FineRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}