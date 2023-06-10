using Gestor_de_gastos_pessoais_data.Domain.Interfaces.InterfacesIdentity;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Componets
{
    public class ModalComponetLayout : ViewComponent
    {
        private readonly ITipoGastosRepository _tipoGastosRepository;

        public ModalComponetLayout(ITipoGastosRepository tipoGastosRepository)
        {
            _tipoGastosRepository = tipoGastosRepository;
        }

        public  IViewComponentResult Invoke()
        {
            var todos = Task.Run(async () => await _tipoGastosRepository.ReTornaTodos()).GetAwaiter().GetResult();

            ViewBag.TiposGastos = todos;


            return View();
        }
    }
}
