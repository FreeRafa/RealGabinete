using RealGabinete.Domain;
using RealGabinete.Domain.Interfaces;
using RealGabinete.Infrastructure.Data;
using System.Threading.Tasks;

namespace RealGabinete.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork   
    {
        private readonly RealGabineteContext _context;   

        public IAutorRepository Autores { get; }
        public ISalaRepository Salas { get; }
        public IEmprestimoRepository Emprestimos { get; }
        public IReservaRepository Reservas { get; }
        public IEditoraRepository Editoras { get; }
        public ICategoriaRepository Categorias { get; }
        public IPrateleiraRepository Prateleiras { get; }
        public ILivrosRepository Livros { get; }
        public IExemplaresRepository Exemplares { get; }
        public ILeitoresRepository Leitores { get; }
        public IBibliotecarioRepository Bibliotecarios { get; }
        public IMultasRepository Multas { get; }

        public UnitOfWork(RealGabineteContext context)   
        {
            _context = context;

            Autores = new AutorRepositorie(_context);       
            Salas = new SalaRepositorie(_context);
            Emprestimos = new EmprestimoRepositorie(_context);
            Reservas = new ReservaRepositorie(_context);
            Editoras = new EditoraRepositorie(_context);
            Categorias = new CategoriaRepositore(_context);
            Prateleiras = new PrateleiraRepositorie(_context);
            Livros = new LivrosRepositorie(_context);
            Exemplares = new ExemplaresRepositorie(_context);
            Leitores = new LeitoresRepositorie(_context);
            Bibliotecarios = new BibliotecarioRepositorie(_context);
            Multas = new MultaRepositorie(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}