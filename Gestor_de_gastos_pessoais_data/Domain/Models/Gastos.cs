using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime DataCadastrado { get; set; }
        public DateTime DataGasto { get; set; }
        public int LocalGastoid { get; set; }
        [ForeignKey("LocalGastoid")]
        public LocalGasto? LocalGasto { get; set; }
        public int TipoGastosId { get; set; }
        [ForeignKey("TipoGastosId")]
        public TipoGastos? tipoGastos { get; set; }
        public string? UsuarioSistemaId { get; set; } // Chave estrangeira
        [ForeignKey("UsuarioSistemaId")]
        public UsuarioSistema User { get; set; }
        
    }
}
