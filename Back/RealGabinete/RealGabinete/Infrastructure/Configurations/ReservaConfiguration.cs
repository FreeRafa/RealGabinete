using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.Property(r => r.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            // "Pendente" (não "Ativa") — para bater certo com o enum
            // StatusReserva e com o CK_Reservas_Status do SQL original.
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Reserva_Status",
                "Status IN ('Pendente','Concluida','Cancelada')"));
        }
    }
}