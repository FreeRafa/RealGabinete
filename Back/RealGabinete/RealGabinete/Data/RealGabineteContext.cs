using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealGabinete.Models;


namespace RealGabinete.Data
{
    // DbContext é a classe base do entity framework que representa uma sessão com o banco de dados e permite realizar operações de consulta e persistência de dados.
    internal class RealGabineteContext : DbContext
    {
        // Este construtor recebe as "opções" (connection string, provider, etc.)
        // já configuradas de fora — normalmente pelo Program.cs através de Injeção de Dependência.
        // Não colocamos a connection string aqui dentro: isso acoplaria o DbContext
        // a uma configuração fixa e dificultaria testes (ex: usar uma BD em memória nos testes).

        public RealGabineteContext(DbContextOptions<RealGabineteContext> options) : base(options)
        {
        }

        // DbSet representa uma coleção de entidades do tipo especificado que podem ser consultadas e salvas no banco de dados.
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
            modelBuilder.Entity<Emprestimo>()
                .HasIndex(e => e.ExemplarId)
                .IsUnique()
                .HasFilter("[Data_Devolucao] IS NULL");

            modelBuilder.Entity<Exemplar>()
                .ToTable(t => t.HasCheckConstraint("CK_Exemplar_Estado", "Estado IN ('Disponivel', 'Emprestado', 'Reservado', 'Danificado', 'Perdido')"));

            modelBuilder.Entity<Reserva>()
                .ToTable(t => t.HasCheckConstraint("CK_Reserva_Estado", "Estado IN ('Ativa', 'Concluida', 'Cancelada')"));

            modelBuilder.Entity<Multa>()
                .ToTable(t => t.HasCheckConstraint("CK_Multa_Estado", "Paga IN (0, 1)"));

        }

    }
}
