using Gestor_de_gastos_pessoais_data.Contexto;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces.InterfacesIdentity;
using Gestor_de_gastos_pessoais_data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Repository
{
    public class TipoGastosRepository : ITipoGastosRepository
    {
        private readonly AppDbContext _context;

        public TipoGastosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoGastos> Adicionar(TipoGastos entity)
        {
            var addedEntity = await _context.tipoGastos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<TipoGastos> Atualizar(TipoGastos entity)
        {
            _context.tipoGastos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoGastos> PegaPorId(int? id)
        {
            return await _context.tipoGastos.FindAsync(id);
        }

        public async Task<TipoGastos> Remover(TipoGastos entity)
        {
            _context.tipoGastos.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TipoGastos>> ReTornaTodos()
        {
            var teste = await _context.tipoGastos.ToListAsync();
            return teste;
        }
    }

}
