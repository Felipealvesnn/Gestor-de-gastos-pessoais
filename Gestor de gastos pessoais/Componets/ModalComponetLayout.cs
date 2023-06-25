using Gestor_de_gastos_pessoais_data.Domain.Interfaces;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces.InterfacesIdentity;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Componets
{
    public class ModalComponetLayout : ViewComponent
    {
        private readonly ITipoGastosRepository _tipoGastosRepository;
        private readonly ILocalGastosRepository _localGastosRepository;

        public ModalComponetLayout(ITipoGastosRepository tipoGastosRepository, ILocalGastosRepository localGastosRepository)
        {
            _tipoGastosRepository = tipoGastosRepository;
            _localGastosRepository = localGastosRepository;
        }

        public  IViewComponentResult Invoke()
        {
            var todos = Task.Run(async () => await _tipoGastosRepository.ReTornaTodos()).GetAwaiter().GetResult();
            var locais = Task.Run(async () => await _localGastosRepository.ReTornaTodos()).GetAwaiter().GetResult();

            ViewBag.TiposGastos = todos;
            ViewBag.LocaisGastos = locais;


            return View();
        }
    }
}
