using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Models
{
    public class UsuarioSistema : IdentityUser
    {
        [MaxLength(80)]
        public string? whatsapp { get; set; }
        [MaxLength(80)]
        public string? Endereco { get; set; }
        public ICollection<Gastos>? gastos { get; set; }
    }
}
