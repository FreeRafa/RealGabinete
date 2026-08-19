using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Presentation.Menus
{
    public class AuthorMenu
    {
        private readonly AuthorService _authorService;

        public AuthorMenu(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Autores ===");
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
            var authors = await _authorService.GetAllAsync();

            Console.WriteLine();
            if (authors.Count == 0)
            {
                Console.WriteLine("Nenhum autor cadastrado.");
            }
            else
            {
                foreach (var author in authors)
                {
                    Console.WriteLine($"{author.Id} - {author.FirstName} {author.LastName}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id do autor: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var author = await _authorService.GetByIdAsync(id);

                if (author == null)
                {
                    Console.WriteLine("Autor não encontrado.");
                }
                else
                {
                    Console.WriteLine($"{author.Id} - {author.FirstName} {author.LastName}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Primeiro nome: ");
            var firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Último nome: ");
            var lastName = Console.ReadLine() ?? string.Empty;

            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await _authorService.AddAsync(author);

            Console.WriteLine($"\nAutor '{author.FirstName} {author.LastName}' adicionado com sucesso (Id {author.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id do autor a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                Console.WriteLine("Autor não encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo primeiro nome (atual: {author.FirstName}): ");
            var firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName))
                author.FirstName = firstName;

            Console.Write($"Novo último nome (atual: {author.LastName}): ");
            var lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
                author.LastName = lastName;

            await _authorService.UpdateAsync(author);

            Console.WriteLine("\nAutor atualizado com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id do autor a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                Console.WriteLine("Autor não encontrado.");
                Console.ReadKey();
                return;
            }

            await _authorService.RemoveAsync(id);

            Console.WriteLine($"\nAutor '{author.FirstName} {author.LastName}' removido com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}