using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdminProysis.Models
{
    public class VentaTimbre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required]
        public int TiendaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Notas")]
        public string Notas { get; set; }

        //public ICollection<Cliente> Clientes { get; set; }
        public virtual Cliente Clientes { get; set; }

        //public virtual ICollection<CompraTimbreDetalle> CompraTimbresDetalles { get; set; }
    }
}
