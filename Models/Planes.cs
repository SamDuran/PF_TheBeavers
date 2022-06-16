using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Planes
    {
        [Key]
        public int PlanId { get; set; }
        
        public int TipoPlanId { get; set; }

         [Required]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres invalidos para el Nombre.")]
        public string NombrePlan { get; set; } = string.Empty;

        [Required]
        public decimal PrecioPlan { get; set; } 
        
        [Required(ErrorMessage ="Es obligatorio introducir la fecha de plan")]
        public DateTime FechaPLan { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }

    }
}