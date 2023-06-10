using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Interfaces
{
    public interface IRepository<t> 
    {
        Task<IEnumerable<t>> ReTornaTodos();
        Task<t> PegaPorId(int? id);
        Task<t> Adicionar(t entity);
        Task<t> Atualizar(t entity);
        Task<t> Remover(t entity);
    }
}
