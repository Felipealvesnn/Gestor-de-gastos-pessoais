using Gestor_de_gastos_pessoais_data.Contexto;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces;
using Gestor_de_gastos_pessoais_data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Repository
{
    public class GastoRepository : IGastosRepository
    {
        private readonly AppDbContext _context;

        public GastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Gastos> Adicionar(Gastos entity)
        {
            var addedEntity = await _context.gastos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<Gastos> Atualizar(Gastos entity)
        {
            _context.gastos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Gastos> PegaPorId(int? id)
        {
            return await _context.gastos.FindAsync(id);
        }

        public async Task<Gastos> Remover(Gastos entity)
        {
            _context.gastos.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Gastos>> ReTornaTodos()
        {
            return await _context.gastos.ToListAsync();
        }
    }

}
