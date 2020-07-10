using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.AccesoDatos.Data.Repository
{
    public interface IPacRepository : IRepository<Pac>
    {
        IEnumerable<SelectListItem> GetListaPacs();

        void Update(Pac pac);
    }
}
