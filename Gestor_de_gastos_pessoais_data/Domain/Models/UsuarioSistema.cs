using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Models
{
    public class UsuarioSistema : IdentityUser
    {
        public string whatsapp { get; set; }
        public string Endereco { get; set; }
        public ICollection<Gastos> gastos { get; set; }
    }
}
