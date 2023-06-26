using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Models
{
    public class LocalGasto
    {
        public int id { get; set; }
        public string? Descricao { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? PontoReferencia { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string? Cnhpj { get; set; }
        public string? Telefone { get; set; }
        public ICollection< Gastos> gastos { get; set; }


    }
}
