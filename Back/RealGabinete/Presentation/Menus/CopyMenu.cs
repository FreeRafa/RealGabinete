using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;
using RealGabinete.Domain.Enums;


namespace RealGabinete.Presentation.Menus
{
    public class CopyMenu
    {
        private readonly CopyService _copyService;

        public CopyMenu(CopyService copyService)
        {
            _copyService = copyService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Cópias ===");
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
            var copies = await _copyService.GetAllAsync();

            Console.WriteLine();
            if (copies.Count == 0)
            {
                Console.WriteLine("Nenhuma cópia cadastrada.");
            }
            else
            {
                foreach (var copy in copies)
                {
                    Console.WriteLine($"{copy.Id} - {copy.Status} - {copy.Book?.Title} - {copy.Book?.Author?.FirstName} {copy.Book?.Author?.LastName}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id da cópia: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var copy = await _copyService.GetByIdAsync(id);

                if (copy == null)
                {
                    Console.WriteLine("Cópia não encontrada.");
                }
                else
                {
                    Console.WriteLine($"{copy.Id} - {copy.Status} - {copy.Book?.Title} - {copy.Book?.Author?.FirstName} {copy.Book?.Author?.LastName}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Código da cópia: ");
            var code = Console.ReadLine() ?? string.Empty;

            Console.Write("Id do livro (BookId): ");
            var bookInput = Console.ReadLine();
            if (!int.TryParse(bookInput, out int bookId))
            {
                Console.WriteLine("Id do livro inválido.");
                Console.ReadKey();
                return;
            }

            Console.Write("Id da estante (ShelfId, opcional - Enter para pular): ");
            var shelfInput = Console.ReadLine();
            int? shelfId = null;
            if (!string.IsNullOrWhiteSpace(shelfInput) && int.TryParse(shelfInput, out int parsedShelfId))
                shelfId = parsedShelfId;

            var copy = new Copy
            {
                Code = code,
                BookId = bookId,
                ShelfId = shelfId
            };

            await _copyService.AddAsync(copy);

            Console.WriteLine($"\nCópia '{copy.Code}' adicionada com sucesso (Id {copy.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id da cópia a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var copy = await _copyService.GetByIdAsync(id);

            if (copy == null)
            {
                Console.WriteLine("Cópia não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo código (atual: {copy.Code}): ");
            var code = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(code))
                copy.Code = code;

            Console.Write($"Novo BookId (atual: {copy.BookId}): ");
            var bookInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(bookInput) && int.TryParse(bookInput, out int bookId))
                copy.BookId = bookId;

            Console.Write($"Novo ShelfId (atual: {copy.ShelfId?.ToString() ?? "nenhum"}): ");
            var shelfInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(shelfInput) && int.TryParse(shelfInput, out int shelfId))
                copy.ShelfId = shelfId;

            Console.Write($"Novo status (atual: {copy.Status}): ");
            var statusInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(statusInput) && Enum.TryParse<CopyStatus>(statusInput, true, out var status))
                copy.Status = status;

            await _copyService.UpdateAsync(copy);

            Console.WriteLine("\nCópia atualizada com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id da cópia a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var copy = await _copyService.GetByIdAsync(id);

            if (copy == null)
            {
                Console.WriteLine("Cópia não encontrada.");
                Console.ReadKey();
                return;
            }

            await _copyService.RemoveAsync(id);

            Console.WriteLine($"\nCópia '{copy.Code}' removida com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}

