using RealGabinete.Presentation.Menus;

namespace RealGabinete.Presentation
{
    public class MenuPrincipal
    {
        private readonly AuthorMenu _authorMenu;
        private readonly CategoryMenu _categoryMenu;
        private readonly PublisherMenu _publisherMenu;
        private readonly RoomMenu _roomMenu;
        private readonly BookMenu _bookMenu;
        private readonly ShelfMenu _shelfMenu;
        private readonly CopyMenu _copyMenu;

        public MenuPrincipal(AuthorMenu authorMenu, CategoryMenu categoryMenu, PublisherMenu publisherMenu, RoomMenu roomMenu, BookMenu bookMenu, ShelfMenu shelfMenu, CopyMenu copyMenu)
        {
            _authorMenu = authorMenu;
            _categoryMenu = categoryMenu;
            _publisherMenu = publisherMenu;
            _roomMenu = roomMenu;
            _bookMenu = bookMenu;
            _shelfMenu = shelfMenu;
            _copyMenu = copyMenu;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== RealGabinete ===");
                Console.WriteLine("1 - Gerenciar Autores");
                Console.WriteLine("2 - Gerenciar Categorias");
                Console.WriteLine("3 - Gerenciar Editoras");
                Console.WriteLine("4 - Gerenciar Salas");
                Console.WriteLine("5 - Gerenciar Livros");
                Console.WriteLine("6 - Gerenciar Estantes");
                Console.WriteLine("7 - Gerenciar Cópias");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await _authorMenu.ExibirAsync();
                        break;

                    case "2":
                        await _categoryMenu.ExibirAsync();
                        break;

                        case "3":
                            await _publisherMenu.ExibirAsync();
                        break;

                        case "4":
                            await _roomMenu.ExibirAsync();
                        break;

                        case "5":
                            await _bookMenu.ExibirAsync();
                            break;

                        case "6":
                            await _shelfMenu.ExibirAsync();
                        break;

                    case "7":
                        await _copyMenu.ExibirAsync();
                        break;

                    case "0":
                        Console.WriteLine("Encerrando...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}