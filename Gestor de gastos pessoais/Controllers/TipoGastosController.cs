using Gestor_de_gastos_pessoais_data.Domain.Interfaces.InterfacesIdentity;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Controllers
{
    public class TipoGastosController : Controller
    {
        private readonly ITipoGastosRepository _tipoGastosRepository;

        public TipoGastosController(ITipoGastosRepository tipoGastosRepository)
        {
            _tipoGastosRepository = tipoGastosRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
