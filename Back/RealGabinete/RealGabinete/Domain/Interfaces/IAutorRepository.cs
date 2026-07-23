using RealGabinete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealGabinete.Domain.Interfaces
{
    internal interface IAutorRepository
    {
        Task<List<Autor>> ObterTodosAsync();
        // Devolve todos os Autores da BD. Task<List<>> porque é assíncrono e pode devolver 0, 1 ou vários registos (nunca null — no máximo lista vazia).

        Task<Autor?> ObterPorIdAsync(int id);
        // Busca um Autor por Id. O "?" existe porque o Id pode não existir na BD — nesse caso devolve null em vez de erro.

        Task<Autor> AdicionarAsync(Autor autor);
        // Insere um novo Autor. Devolve o próprio Autor (sem "?") porque depois do INSERT ele sempre existe — e já vem com o Id gerado pelo IDENTITY do SQL Server.

        Task AtualizarAsync(Autor autor);
        // Atualiza um Autor existente. Sem tipo de retorno (Task simples) porque quem chamou já tem o objeto — não há nada novo a devolver.

        Task RemoverAsync(int id);
        // Remove um Autor pelo Id. Recebe só o int (não o objeto inteiro) porque é o repositório que se encarrega de buscar e remover numa única chamada.
    }
}
