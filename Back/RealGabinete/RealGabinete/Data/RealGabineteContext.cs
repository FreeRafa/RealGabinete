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
    }
}
