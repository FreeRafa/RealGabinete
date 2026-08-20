using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;

namespace RealGabinete.Presentation.Menus
{
    public class CategoryMenu
    {
        private readonly CategoryService _categoryService;

        public CategoryMenu(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Categorias ===");
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
            var categories = await _categoryService.GetAllAsync();

            Console.WriteLine();
            if (categories.Count == 0)
            {
                Console.WriteLine("Nenhuma categoria cadastrada.");
            }
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id da categoria: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var category = await _categoryService.GetByIdAsync(id);

                if (category == null)
                {
                    Console.WriteLine("Categoria não encontrada.");
                }
                else
                {
                    Console.WriteLine($"{category.Id} - {category.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Nome da categoria: ");
            var name = Console.ReadLine() ?? string.Empty;

            var category = new Category
            {
                Name = name
            };

            await _categoryService.AddAsync(category);

            Console.WriteLine($"\nCategoria '{category.Name}' adicionada com sucesso (Id {category.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id da categoria a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                Console.WriteLine("Categoria não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Novo nome (atual: {category.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                category.Name = name;

            await _categoryService.UpdateAsync(category);

            Console.WriteLine("\nCategoria atualizada com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id da categoria a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                Console.WriteLine("Categoria não encontrada.");
                Console.ReadKey();
                return;
            }

            await _categoryService.RemoveAsync(id);

            Console.WriteLine($"\nCategoria '{category.Name}' removida com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}