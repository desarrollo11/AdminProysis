using AdminProysis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.AccesoDatos.Data.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<SelectListItem> GetListaClientes();

        void Update(Cliente cliente);
    }
}
