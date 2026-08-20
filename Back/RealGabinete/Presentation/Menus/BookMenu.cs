using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Presentation.Menus
{
    public class BookMenu
    {
        private readonly BookService _bookService;

        public BookMenu(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Livros ===");
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
            var books = await _bookService.GetAllAsync();

            Console.WriteLine();
            if (books.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Id} - {book.Title}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id do livro: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var book = await _bookService.GetByIdAsync(id);

                if (book == null)
                {
                    Console.WriteLine("Livro não encontrado.");
                }
                else
                {
                    Console.WriteLine($"{book.Id} - {book.Title}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("ISBN: ");
            var isbn = Console.ReadLine() ?? string.Empty;

            Console.Write("Título: ");
            var title = Console.ReadLine() ?? string.Empty;

            var book = new Book
            {
                ISBN = isbn,
                Title = title
            };

            await _bookService.AddAsync(book);

            Console.WriteLine($"\nLivro '{book.Title}' adicionado com sucesso (Id {book.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id do livro a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                Console.WriteLine("Livro não encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo ISBN (atual: {book.ISBN}): ");
            var isbn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(isbn))
                book.ISBN = isbn;

            Console.Write($"Novo título (atual: {book.Title}): ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
                book.Title = title;

            await _bookService.UpdateAsync(book);

            Console.WriteLine("\nLivro atualizado com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id do livro a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                Console.WriteLine("Livro não encontrado.");
                Console.ReadKey();
                return;
            }

            await _bookService.RemoveAsync(id);

            Console.WriteLine($"\nLivro '{book.Title}' removido com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}
