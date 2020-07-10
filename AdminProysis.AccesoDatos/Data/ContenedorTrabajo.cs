using AdminProysis.AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Pac = new PacRepository(_db);
            Cliente = new ClienteRepository(_db);
            Sistema = new SistemaRepository(_db);
            CompraTimbre = new CompraTimbreRepository(_db);

        }

        public IPacRepository Pac { get; private set; }
        public IClienteRepository Cliente { get; private set; }
        public ISistemaRepository Sistema { get; private set; }
        public ICompraTimbreRepository CompraTimbre { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
