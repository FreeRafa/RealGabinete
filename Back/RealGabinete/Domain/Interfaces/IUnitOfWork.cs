using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        ICategoryRepository Categories { get; }
        IPublisherRepository Publishers { get; }
        IRoomRepository Rooms { get; }
        IShelfRepository Shelves { get; }
        IReaderRepository Readers { get; }
        IBookRepository Books { get; }
        ICopyRepository Copies { get; }
        ILibrarianRepository Librarians { get; }
        ILoanRepository Loans { get; }
        IReservationRepository Reservations { get; }
        IFineRepository Fines { get; }

        Task<int> SaveChangesAsync();
    }
}
