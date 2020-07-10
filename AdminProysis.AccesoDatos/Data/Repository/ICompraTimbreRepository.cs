using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.AccesoDatos.Data.Repository
{
    public interface ICompraTimbreRepository : IRepository<CompraTimbre>
    {
        IEnumerable<SelectListItem> GetListaComprasTimbres();

        void Update(CompraTimbre compraTimbre);
    }
}
