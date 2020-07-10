using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AdminProysis.AccesoDatos.Data.Repository
{
    public interface ISistemaRepository : IRepository<Sistema>
    {
        IEnumerable<SelectListItem> GetListaSistemas();

        void Update(Sistema sistema);
    }
}
