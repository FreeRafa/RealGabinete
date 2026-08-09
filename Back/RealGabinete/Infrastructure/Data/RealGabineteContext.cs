using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Data
{
    public class RealGabineteContext : DbContext
    {
        public RealGabineteContext(DbContextOptions<RealGabineteContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Copy> Copies => Set<Copy>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Shelf> Shelves => Set<Shelf>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<Librarian> Librarians => Set<Librarian>();
        public DbSet<Fine> Fines => Set<Fine>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealGabineteContext).Assembly);
        }
    }
}