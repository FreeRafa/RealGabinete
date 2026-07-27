using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealGabinete.Domain.Entities;
using RealGabinete.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RealGabinete.Domain.Interfaces;


namespace RealGabinete.Infrastructure.Repositories
{
    public class AutorRepositorie : IAutorRepository
    {
        // Guarda a referência ao contexto. "readonly" porque só é
        // atribuído uma vez, no construtor, e nunca mais muda.
        private readonly RealGabineteContext _context;

        // Injeção de Dependência: quem cria este repositório (mais tarde,
        // o Program.cs via AddScoped) passa o DbContext já configurado.
        public AutorRepositorie(RealGabineteContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>> ObterTodosAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor?> ObterPorIdAsync(int id)
        {
            // FindAsync procura primeiro pela chave primária — é o método
            // mais eficiente para "buscar por Id", porque o EF Core primeiro
            // verifica se a entidade já está em memória (tracked) antes de
            // ir à BD.
            return await _context.Autores.FindAsync(id);
        }

        public async Task<Autor> AdicionarAsync(Autor autor)
        {
            // Add() só marca a entidade como "Added" no Change Tracker —
            // ainda NÃO grava na BD.
            _context.Autores.Add(autor);

            // Aqui SIM grava — mas repara: estamos ainda na Opção A
            // (repositório grava sozinho). Quando fizeres a UnitOfWork,
            // este SaveChangesAsync vai SAIR daqui.
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task AtualizarAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int Id)
        {
            var autor = await _context.Autores.FindAsync(Id);
            if (autor != null) 
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
