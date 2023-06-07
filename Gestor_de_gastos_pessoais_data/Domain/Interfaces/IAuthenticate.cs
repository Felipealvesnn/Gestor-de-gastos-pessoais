using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Domain.Interfaces
{
    public interface IAuthenticate
    {
        Task<IdentityUser> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string usename,string password);
    
        Task logout();
    }
}
