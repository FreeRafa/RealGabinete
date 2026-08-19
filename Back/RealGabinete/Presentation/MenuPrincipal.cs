using RealGabinete.Presentation.Menus;

namespace RealGabinete.Presentation
{
    public class MenuPrincipal
    {
        private readonly AuthorMenu _authorMenu;

        public MenuPrincipal(AuthorMenu authorMenu)
        {
            _authorMenu = authorMenu;
        }

        public async Task ExibirAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== RealGabinete ===");
                Console.WriteLine("1 - Gerenciar Autores");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await _authorMenu.ExibirAsync();
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