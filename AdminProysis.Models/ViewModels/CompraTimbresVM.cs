using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminProysis.Models.ViewModels
{
    public class CompraTimbresVM
    {
        public CompraTimbre CompraTimbres { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
    }
}
