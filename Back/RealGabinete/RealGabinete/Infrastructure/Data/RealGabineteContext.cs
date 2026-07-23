using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Infrastructure.Data
{
    // DbContext é a classe base do Entity Framework que representa uma sessão
    // com o banco de dados e permite realizar operações de consulta e persistência.
    public class RealGabineteContext : DbContext
    {
        // Recebe as opções (connection string, provider, etc.) já configuradas
        // de fora — normalmente pelo Program.cs através de Injeção de Dependência.
        // Não colocamos a connection string aqui dentro: isso acoplaria o DbContext
        // a uma configuração fixa e dificultaria testes (ex: BD em memória).
        public RealGabineteContext(DbContextOptions<RealGabineteContext> options) : base(options)
        {
        }

        public DbSet<Sala> Salas => Set<Sala>();
        public DbSet<Prateleira> Prateleiras => Set<Prateleira>();
        public DbSet<Autor> Autores => Set<Autor>();
        public DbSet<Editora> Editoras => Set<Editora>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Livro> Livros => Set<Livro>();
        public DbSet<Exemplar> Exemplares => Set<Exemplar>();
        public DbSet<Leitor> Leitores => Set<Leitor>();
        public DbSet<Bibliotecario> Bibliotecarios => Set<Bibliotecario>();
        public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
        public DbSet<Reserva> Reservas => Set<Reserva>();
        public DbSet<Multa> Multas => Set<Multa>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Em vez de configurar cada entidade aqui dentro (o que faria esta
            // classe crescer descontroladamente), o EF Core vai à assembly da
            // Infrastructure e aplica automaticamente TODAS as classes que
            // implementarem IEntityTypeConfiguration<T> na pasta Configurations.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealGabineteContext).Assembly);
        }
    }
}