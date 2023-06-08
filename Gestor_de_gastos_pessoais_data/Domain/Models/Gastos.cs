using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Models
{
    public class Gastos
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int LocalgastoId { get; set; }
        public LocalGasto? LocalGasto { get; set; }
        public int TipogastoId { get; set; }
        public TipoGastos? tipoGastos { get; set; }
        public string UserId { get; set; } // Chave estrangeira
        public UsuarioSistema User { get; set; }
        
    }
}
