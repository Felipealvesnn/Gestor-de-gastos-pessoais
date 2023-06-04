using Gestor_de_gastos_pessoais_domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_gastos_pessoais_data.Identity
{
    public class AuthenticateService: IAuthenticate
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _SignInmanager;

        public AuthenticateService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _usermanager = userManager;
            _SignInmanager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _SignInmanager.PasswordSignInAsync(email.ToUpper(), password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email,string usename, string password)
        {
            var aplicacaodousuario = new IdentityUser
            {
                UserName = usename.ToUpper(),
                Email = email,
            };
            var result = await _usermanager.CreateAsync(aplicacaodousuario, password);
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(aplicacaodousuario, "User");
                await _SignInmanager.SignInAsync(aplicacaodousuario, isPersistent: false);
            }
            return result.Succeeded;
        }

        public async Task logout()
        {
            await _SignInmanager.SignOutAsync();
        }
    }
}

