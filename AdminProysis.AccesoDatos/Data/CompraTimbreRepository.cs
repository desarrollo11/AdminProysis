using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AdminProysis.AccesoDatos.Data
{
    public class CompraTimbreRepository : Repository<CompraTimbre>, ICompraTimbreRepository
    {
        private readonly ApplicationDbContext _db;
        public CompraTimbreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaComprasTimbres()
        {
            return _db.CompraTimbres.Select(i => new SelectListItem()
            {
                Text = i.PacId.ToString(),
                Value = i.Id.ToString()
            });
        }

        public void Update(CompraTimbre compraTimbre)
        {
            var objDesdeDb = _db.CompraTimbres.FirstOrDefault(s => s.Id == compraTimbre.Id);
            objDesdeDb.PacId = compraTimbre.PacId;
            objDesdeDb.Fecha = compraTimbre.Fecha;
            objDesdeDb.Cantidad = compraTimbre.Cantidad;
            objDesdeDb.Notas = compraTimbre.Notas;

            _db.SaveChanges();


        }
    }
}
