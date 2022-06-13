using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoPlanes
    {
        [Key]
        public int PlanId { get; set; }

        [Required]
        [Display(Name = "Tipo de Plan")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string NombrePlan { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Precio")]
        public decimal PrecioPlan { get; set; }

        public DateTime FechaCreacion { get; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        public override string ToString()
        {
            return NombrePlan;
        }
    }
}