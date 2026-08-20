using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealGabinete.Application.Services;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using RealGabinete.Infrastructure.Repositories;
using RealGabinete.Presentation;
using RealGabinete.Presentation.Menus;

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

services.AddScoped<AuthorService>();
services.AddScoped<AuthorMenu>();

services.AddScoped<CategoryService>();
services.AddScoped<CategoryMenu>();

services.AddScoped<PublisherMenu>();
services.AddScoped<PublisherService>();

services.AddScoped<RoomService>();
services.AddScoped<RoomMenu>();

services.AddScoped<ShelfService>();
services.AddScoped<ShelfMenu>();

services.AddScoped<BookService>();
services.AddScoped<BookMenu>();

services.AddScoped<CopyService>();
services.AddScoped<CopyMenu>();

services.AddScoped<MenuPrincipal>();

// 3. Construir o ServiceProvider e abrir um scope
using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

// 4. Pedir o MenuPrincipal e iniciar o app
var menuPrincipal = scope.ServiceProvider.GetRequiredService<MenuPrincipal>();
await menuPrincipal.ExibirAsync();