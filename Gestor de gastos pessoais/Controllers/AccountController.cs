using Gestor_de_gastos_pessoais.VieswsModel;
using Gestor_de_gastos_pessoais_domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;

        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        public IActionResult Login(string url)
        {
            return View("~/Views/Account/Login.cshtml", new LoginVM()
            {
                ReturnUrl = url
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            //if (!ModelState.IsValid)
            //    return View(loginVM);
            var result = await _authentication.Authenticate(loginVM.UserName, loginVM.Password);


            if (result)
            {
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginVM.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Falha ao realizar o login!!");
            }


          
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            var result = await _authentication.RegisterUser(loginVM.Email, loginVM.UserName, loginVM.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return View(loginVM);
            }
       
        }

       // [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;

            await _authentication.logout();
            return Redirect("/Account/Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
