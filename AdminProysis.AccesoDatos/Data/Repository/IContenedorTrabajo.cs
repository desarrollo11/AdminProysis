using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IPacRepository Pac { get; }
        IClienteRepository Cliente { get; }
        ISistemaRepository Sistema { get; }
        ICompraTimbreRepository CompraTimbre { get; }

        void Save();

    }
}
