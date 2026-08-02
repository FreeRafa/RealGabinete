
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(l => l.Valor)
                .HasColumnType("decimal(10,2)");
            
        }
    }
}
