using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;
namespace RealGabinete.Presentation.Menus
{
    public class ShelfMenu
    {
        private readonly ShelfService _shelfService;

        public ShelfMenu(ShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Estantes ===");
                Console.WriteLine("1 - Listar todos");
                Console.WriteLine("2 - Buscar por Id");
                Console.WriteLine("3 - Adicionar");
                Console.WriteLine("4 - Atualizar");
                Console.WriteLine("5 - Remover");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await ListarAsync();
                        break;
                    case "2":
                        await BuscarPorIdAsync();
                        break;
                    case "3":
                        await AdicionarAsync();
                        break;
                    case "4":
                        await AtualizarAsync();
                        break;
                    case "5":
                        await RemoverAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task ListarAsync()
        {
            var shelves = await _shelfService.GetAllAsync();

            Console.WriteLine();
            if (shelves.Count == 0)
            {
                Console.WriteLine("Nenhuma estante cadastrada.");
            }
            else
            {
                foreach (var shelf in shelves)
                {
                    Console.WriteLine($"{shelf.Id} - {shelf.Code}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id da estante: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var shelf = await _shelfService.GetByIdAsync(id);

                if (shelf == null)
                {
                    Console.WriteLine("Estante não encontrada.");
                }
                else
                {
                    Console.WriteLine($"{shelf.Id} - {shelf.Code}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Código da estante: ");
            var code = Console.ReadLine() ?? string.Empty;

            var shelf = new Shelf
            {
                Code = code
            };

            await _shelfService.AddAsync(shelf);

            Console.WriteLine($"\nEstante '{shelf.Code}' adicionada com sucesso (Id {shelf.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id da estante a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var shelf = await _shelfService.GetByIdAsync(id);

            if (shelf == null)
            {
                Console.WriteLine("Estante não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo código (atual: {shelf.Code}): ");
            var code = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(code))
                shelf.Code = code;

            await _shelfService.UpdateAsync(shelf);

            Console.WriteLine("\nEstante atualizada com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id da estante a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var shelf = await _shelfService.GetByIdAsync(id);

            if (shelf == null)
            {
                Console.WriteLine("Estante não encontrada.");
                Console.ReadKey();
                return;
            }

            await _shelfService.RemoveAsync(id);

            Console.WriteLine($"\nEstante '{shelf.Code}' removida com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}
