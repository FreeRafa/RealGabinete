using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasIndex(l => l.CopyId)          // índice baseado na coluna CopyId
                .IsUnique()                        // torna esse índice único...
                .HasFilter("[ReturnDate] IS NULL"); // ...mas só entre as linhas onde ReturnDate é nulo
        }
    }
}