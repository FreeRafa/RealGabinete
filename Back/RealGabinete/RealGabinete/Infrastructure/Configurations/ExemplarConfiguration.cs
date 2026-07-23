using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class ExemplarConfiguration : IEntityTypeConfiguration<Exemplar>
    {
        public void Configure(EntityTypeBuilder<Exemplar> builder)
        {
            // Sem isto, o EF Core grava o enum como número (0,1,2...)
            // e o CHECK abaixo (que compara texto) nunca faria sentido.
            builder.Property(e => e.Estado)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Exemplar_Estado",
                "Estado IN ('Disponivel','Emprestado','Reservado','Danificado','Perdido')"));
        }
    }
}