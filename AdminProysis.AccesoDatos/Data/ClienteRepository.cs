using AdminProysis.AccesoDatos.Data.Repository;
using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AdminProysis.AccesoDatos.Data
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;
        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaClientes()
        {
            return _db.Pac.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Cliente cliente)
        {
            var objDesdeDb = _db.Cliente.FirstOrDefault(s => s.Id == cliente.Id);
            objDesdeDb.Nombre = cliente.Nombre;
            objDesdeDb.Direccion = cliente.Direccion;
            objDesdeDb.Cp = cliente.Cp;
            objDesdeDb.Ciudad = cliente.Ciudad;
            objDesdeDb.Telefono = cliente.Telefono;
            objDesdeDb.Email = cliente.Email;
            objDesdeDb.Contacto = cliente.Contacto;
            objDesdeDb.Notas = cliente.Notas;

            _db.SaveChanges();


        }
    }
}
