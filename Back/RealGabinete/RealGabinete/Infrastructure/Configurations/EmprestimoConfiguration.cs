using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            // Garante, ao nível da base de dados, que um mesmo Exemplar
            // não pode ter dois empréstimos ativos em simultâneo.
            // O filtro tem de usar o nome real da coluna: DataDevolucaoReal.
            builder.HasIndex(e => e.ExemplarId)
                .IsUnique()
                .HasFilter("[DataDevolucaoReal] IS NULL");
        }
    }
       
}