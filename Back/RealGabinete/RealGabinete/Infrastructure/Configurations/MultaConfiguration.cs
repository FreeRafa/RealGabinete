using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class MultaConfiguration : IEntityTypeConfiguration<Multa>
    {
        public void Configure(EntityTypeBuilder<Multa> builder)
        {
            builder.Property(m => m.Valor)
                .HasColumnType("decimal(10,2)");

            // Não precisa de CHECK para "Paga IN (0,1)" — Paga é bool,
            // o EF Core mapeia para "bit" no SQL Server, que já só
            // aceita 0 ou 1 por definição do próprio tipo de coluna.
        }
    }
}