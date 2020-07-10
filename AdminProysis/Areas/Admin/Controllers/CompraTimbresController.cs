using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminProysis.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class CompraTimbresController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CompraTimbresController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(CompraTimbre compraTimbre)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.CompraTimbre.Add(compraTimbre);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(compraTimbre);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CompraTimbre compraTimbre = new CompraTimbre();
            compraTimbre = _contenedorTrabajo.CompraTimbre.Get(id);
            if (compraTimbre == null)
            {
                return NotFound();
            }

            return View(compraTimbre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompraTimbre compraTimbre)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.CompraTimbre.Update(compraTimbre);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(compraTimbre);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.CompraTimbre.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.CompraTimbre.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error eliminando la compra de timbres" });
            }

            _contenedorTrabajo.CompraTimbre.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Compra de timbres eliminada correctamente" });
        }
        #endregion
    }
}
