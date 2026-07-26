using RealGabinete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealGabinete.Domain
{
    public interface IUnitOfWork
    {
        // Uma propriedade "get" para cada repositório que já tens.
        // Repara: NÃO tem "set" — só queremos LER o repositório,
        // nunca substituí-lo por outro de fora.
        IAutorRepository Autores { get; }
        ISalaRepository Salas { get; }
        IEmprestimoRepository Emprestimos { get; }
        IReservaRepository Reserva { get; } 
        IEditoraRepository Editora { get; }
        ICategoriaRepository Categorias { get; }
        IPrateleiraRepository Prateles { get; }
        ILivrosRepository Livros { get; }
        IExemplaresRepository Exemplares { get; }
        ILeitoresRepository Leitores { get; }
        IBibliotecarioRepository Bibliotecario { get; }
        IMultasRepository Multas { get; }

        // ... (as restantes 8, mesmo padrão)

        // O único método que efetivamente grava tudo na BD.
        // Devolve Task<int> porque o SaveChangesAsync do EF Core
        // devolve o número de linhas afetadas — útil, por exemplo,
        // para confirmares "sim, alguma coisa foi mesmo gravada".
        Task<int> SaveChangesAsync();
    }
}
