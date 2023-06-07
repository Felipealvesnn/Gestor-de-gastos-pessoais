using Gestor_de_gastos_pessoais_data.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        public async Task<IdentityUser?> Authenticate(string UserNaame, string password)
        {
            var user = await _usermanager.FindByNameAsync(UserNaame.ToUpper());
          
            if( user != null) {

                var result = await _SignInmanager.PasswordSignInAsync(user, password, false, lockoutOnFailure: false);
                return user;
            }

            return null;
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

