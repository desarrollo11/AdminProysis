using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AdminProysis.AccesoDatos.Data
{
    public class PacRepository : Repository<Pac>, IPacRepository
    {
        private readonly ApplicationDbContext _db;
        public PacRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaPacs()
        {
            return _db.Pac.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Pac pac)
        {
            var objDesdeDb = _db.Pac.FirstOrDefault(s => s.Id == pac.Id);
            objDesdeDb.Nombre = pac.Nombre;
            objDesdeDb.Contacto = pac.Contacto;
            objDesdeDb.EmailContacto = pac.EmailContacto;
            objDesdeDb.Telefono = pac.Telefono;
            objDesdeDb.ContactoSoporte = pac.ContactoSoporte;
            objDesdeDb.EmailSoporte = pac.EmailSoporte;
            objDesdeDb.TelefonoSoporte = pac.TelefonoSoporte;
            objDesdeDb.Pagina = pac.Pagina;



            _db.SaveChanges();


        }
    }
}
