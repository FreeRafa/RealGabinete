using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Presentation.Menus
{
    public class PublisherMenu
    {
        private readonly PublisherService _publisherService;

        public PublisherMenu(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Editoras ===");
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
            var publishers = await _publisherService.GetAllAsync();

            Console.WriteLine();
            if (publishers.Count == 0)
            {
                Console.WriteLine("Nenhuma editora cadastrada.");
            }
            else
            {
                foreach (var publisher in publishers)
                {
                    Console.WriteLine($"{publisher.Id} - {publisher.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id da editora: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var publisher = await _publisherService.GetByIdAsync(id);

                if (publisher == null)
                {
                    Console.WriteLine("Editora não encontrada.");
                }
                else
                {
                    Console.WriteLine($"{publisher.Id} - {publisher.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Nome da editora: ");
            var name = Console.ReadLine() ?? string.Empty;

            var publisher = new Publisher
            {
                Name = name
            };

            await _publisherService.AddAsync(publisher);

            Console.WriteLine($"\nEditora '{publisher.Name}' adicionada com sucesso (Id {publisher.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id da editora a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var publisher = await _publisherService.GetByIdAsync(id);

            if (publisher == null)
            {
                Console.WriteLine("Editora não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo nome (atual: {publisher.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                publisher.Name = name;

            await _publisherService.UpdateAsync(publisher);

            Console.WriteLine("\nEditora atualizada com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id da editora a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var publisher = await _publisherService.GetByIdAsync(id);

            if (publisher == null)
            {
                Console.WriteLine("Editora não encontrada.");
                Console.ReadKey();
                return;
            }

            await _publisherService.RemoveAsync(id);

            Console.WriteLine($"\nEditora '{publisher.Name}' removida com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}