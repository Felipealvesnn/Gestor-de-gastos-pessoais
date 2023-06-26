using Gestor_de_gastos_pessoais_data.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class LocalGastosAdmController : Controller
    {
        // GET: LocalGastosAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LocalGastosAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocalGastosAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalGastosAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalGasto model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalGastosAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocalGastosAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalGastosAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocalGastosAdmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
