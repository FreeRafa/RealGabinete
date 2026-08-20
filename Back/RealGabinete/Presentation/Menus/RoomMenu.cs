using RealGabinete.Application.Services;
using RealGabinete.Domain.Entities;


namespace RealGabinete.Presentation.Menus
{
    public class RoomMenu
    {
        private readonly RoomService _roomService;

        public RoomMenu(RoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciar Salas ===");
                Console.WriteLine("1 - Listar todas");
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
            var rooms = await _roomService.GetAllAsync();

            Console.WriteLine();
            if (rooms.Count == 0)
            {
                Console.WriteLine("Nenhuma sala cadastrada.");
            }
            else
            {
                foreach (var room in rooms)
                {
                    Console.WriteLine($"{room.Id} - {room.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task BuscarPorIdAsync()
        {
            Console.Write("Id da sala: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
            }
            else
            {
                var room = await _roomService.GetByIdAsync(id);

                if (room == null)
                {
                    Console.WriteLine("Sala não encontrada.");
                }
                else
                {
                    Console.WriteLine($"{room.Id} - {room.Name}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AdicionarAsync()
        {
            Console.Write("Nome da sala: ");
            var name = Console.ReadLine() ?? string.Empty;

            var room = new Room
            {
                Name = name,
            };

            await _roomService.AddAsync(room);

            Console.WriteLine($"\nSala '{room.Name}' adicionada com sucesso (Id {room.Id}).");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task AtualizarAsync()
        {
            Console.Write("Id da sala a atualizar: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var room = await _roomService.GetByIdAsync(id);

            if (room == null)
            {
                Console.WriteLine("Sala não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Nova nome (atual: {room.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                room.Name = name;

            await _roomService.UpdateAsync(room);

            Console.WriteLine("\nSala atualizada com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private async Task RemoverAsync()
        {
            Console.Write("Id da sala a remover: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Id inválido.");
                Console.ReadKey();
                return;
            }

            var room = await _roomService.GetByIdAsync(id);

            if (room == null)
            {
                Console.WriteLine("Sala não encontrada.");
                Console.ReadKey();
                return;
            }

            await _roomService.RemoveAsync(id);

            Console.WriteLine($"\nSala '{room.Name}' removida com sucesso.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}