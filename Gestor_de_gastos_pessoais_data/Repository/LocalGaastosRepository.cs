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
    public class LocalGastosRepository : ILocalGastosRepository
    {
        private readonly AppDbContext _context;

        public LocalGastosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LocalGasto> Adicionar(LocalGasto entity)
        {
            var addedEntity = await _context.localGastos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<LocalGasto> Atualizar(LocalGasto entity)
        {
            _context.localGastos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LocalGasto> PegaPorId(int? id)
        {
            return await _context.localGastos.FindAsync(id);
        }

        public async Task<LocalGasto> Remover(LocalGasto entity)
        {
            _context.localGastos.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<LocalGasto>> ReTornaTodos()
        {
            return await _context.localGastos.ToListAsync();
        }
    }

}
