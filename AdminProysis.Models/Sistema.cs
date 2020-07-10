using System.ComponentModel.DataAnnotations;

namespace AdminProysis.Models
{
    public class Sistema
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nombre del Sistema, requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe de tener de 3 a 100 carácteres.")]
        public string Nombre { get; set; }

        
    }
}
