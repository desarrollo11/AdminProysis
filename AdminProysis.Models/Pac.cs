using System.ComponentModel.DataAnnotations;

namespace AdminProysis.Models
{
    public class Pac
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del PAC requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe de tener de 3 a 50 carácteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Nombre del Contacto requerido")]
        [StringLength(50, ErrorMessage = "El nombre de contacto no debe de exceder de 50 carácteres")]
        public string Contacto { get; set; }

        [Display(Name = "Correo ")]
        public string EmailContacto { get; set; }

        [Required(ErrorMessage = "Teléfono requerido")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }



        [Display(Name = "Contacto de soporte")]
        public string ContactoSoporte { get; set; }

        [Display(Name = "Correo de soporte")]
        public string EmailSoporte { get; set; }

        [Display(Name = "Teléfono de soporte")]
        public string TelefonoSoporte { get; set; }


        [Display(Name = "Página web")]
        public string Pagina { get; set; }
    }
}
