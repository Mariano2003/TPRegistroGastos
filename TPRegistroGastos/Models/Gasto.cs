using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPRegistroGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "La descripción debe tener entre 3 y 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El nombre del comercio es obligatorio.")]
        [StringLength(250, ErrorMessage = "El nombre del comercio no debe superar los 250 caracteres.")]
        public string NombreComercio { get; set; }

       
    }
}
