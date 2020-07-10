using AdminProysis.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminProysis.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "R.F.C.")]
        [StringLength(15, ErrorMessage = "El RFC debe de tener hasta 14 caracteres.")]
        public string Rfc { get; set; }

        [Required(ErrorMessage = "Nombre del cliente, requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe de tener de 3 a 100 carácteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Código Postal")]
        public string Cp { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        [Display(Name = "Notas")]
        public string Notas { get; set; }

        public virtual ICollection<CompraTimbre> CompraTimbres { get; set; }


        //[Display(Name = "Usuario de registro")]
        //public string UsuarioRegistro { get; set; }

        //[Display(Name = "Contraseña de registro")]
        //public string ContrasenaRegistro { get; set; }
    }
}
