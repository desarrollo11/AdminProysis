using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminProysis.Areas.Admin.Controllers
{
    // [Authorize]
    [Area("Admin")]
    public class PacsController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public PacsController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Pac pac)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Pac.Add(pac);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pac);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pac pac = new Pac();
            pac = _contenedorTrabajo.Pac.Get(id);
            if (pac == null)
            {
                return NotFound();
            }

            return View(pac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pac pac)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Pac.Update(pac);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pac);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Pac.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Pac.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error eliminando al PAC" });
            }

            _contenedorTrabajo.Pac.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "PAC eliminado correctamente" });
        }
        #endregion



    }
}
