using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealGabinete.Domain.Entities;
using System.Runtime.Intrinsics.X86;

namespace RealGabinete.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasIndex(b => b.ISBN)            // índice baseado na coluna Isbn
                .IsUnique()                        // torna esse índice único...
                .HasFilter("[ReturnDate] IS NULL"); // ...mas só entre as linhas onde ReturnDate é nulo
        }
    }

    //Uma classe de configuração(IEntityTypeConfiguration<T>) só é necessária quando você quer expressar uma regra que a convenção do EF Core não consegue deduzir sozinha.
    //Se a entidade não tem nenhuma regra especial, ela não precisa de configuração nenhuma — o EF Core já mapeia tudo certinho por convenção
    //(como já está acontecendo pra maioria das tuas 12 entidades agora).

}