using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminProysis.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class SistemasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public SistemasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Sistema.Add(sistema);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(sistema);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Sistema sistema = new Sistema();
            sistema = _contenedorTrabajo.Sistema.Get(id);
            if (sistema == null)
            {
                return NotFound();
            }

            return View(sistema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Sistema.Update(sistema);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(sistema);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Sistema.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Sistema.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error eliminando el Sistema" });
            }

            _contenedorTrabajo.Sistema.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Sistema eliminado correctamente" });
        }
        #endregion



    }
}
