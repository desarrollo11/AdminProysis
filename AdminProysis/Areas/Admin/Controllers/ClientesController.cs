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
    //[Authorize]
    [Area("Admin")]
    public class ClientesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ClientesController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Cliente.Add(cliente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cliente cliente = new Cliente();
            cliente = _contenedorTrabajo.Cliente.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Cliente.Update(cliente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Cliente.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Cliente.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error eliminando al Cliente" });
            }

            _contenedorTrabajo.Cliente.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Cliente eliminado correctamente" });
        }
        #endregion
    }
}
