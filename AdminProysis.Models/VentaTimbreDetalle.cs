using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdminProysis.Models
{
    public class VentaTimbreDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompraTimbresId { get; set; }

        //[ForeignKey("CompraTimbresId")]
        //public CompraTimbres CompraTimbres { get; set; }

        public enum Tipo { I, E, N, R }

        
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        public string Serie { get; set; }

        public virtual CompraTimbre CompraTimbres { get; set; }

    }
}
