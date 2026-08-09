using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using RealGabinete.Infrastructure.Repositories;

// 1. Ler a configuração (appsettings.json)
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = config.GetConnectionString("RealGabinete")!;

// 2. Montar o container de Injeção de Dependência
var services = new ServiceCollection();

services.AddDbContext<RealGabineteContext>(options =>
    options.UseSqlServer(connectionString));

services.AddScoped<IUnitOfWork, UnitOfWork>();

// 3. Construir o ServiceProvider e abrir um scope
using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

// 4. Pedir o IUnitOfWork e testar a cadeia completa
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

try
{
    var authors = await unitOfWork.Authors.GetAllAsync();
    Console.WriteLine($"Autores encontrados: {authors.Count}");
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao aceder à base de dados: " + ex.Message);
}