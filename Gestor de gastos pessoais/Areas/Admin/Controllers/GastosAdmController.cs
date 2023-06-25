using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_gastos_pessoais.Areas.AreaAdm.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class GastosAdmController : Controller
    {
        // GET: GastosAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GastosAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GastosAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GastosAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GastosAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GastosAdmController/Edit/5
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

        // GET: GastosAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GastosAdmController/Delete/5
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
