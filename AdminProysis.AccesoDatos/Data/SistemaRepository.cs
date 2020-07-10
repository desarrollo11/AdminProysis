using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AdminProysis.AccesoDatos.Data
{
    public class SistemaRepository : Repository<Sistema>, ISistemaRepository
    {
        private readonly ApplicationDbContext _db;
        public SistemaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaSistemas()
        {
            return _db.Sistema.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Sistema sistema)
        {
            var objDesdeDb = _db.Sistema.FirstOrDefault(s => s.Id == sistema.Id);
            objDesdeDb.Nombre = sistema.Nombre;
           
            _db.SaveChanges();


        }
    }
}
