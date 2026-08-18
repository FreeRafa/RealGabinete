using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder
                .HasIndex(l => l.Username)            // índice baseado na coluna Username
                .IsUnique()                        // torna esse índice único...
                .HasFilter("[ReturnDate] IS NULL"); // ...mas só entre as linhas onde ReturnDate é nulo
        }
    }
}