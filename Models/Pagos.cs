using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres invalidos para el Nombre.")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres invalidos para el Apellido.")]
        public string ApellidoCliente { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Monto a pagar")]
        public double MontoPago { get; set; }
        
        [Required(ErrorMessage ="Es obligatorio introducir la fecha de pago")]
        public DateTime FechaPago { get; set; }
        public string? Comentario { get; set; }

        
    }
    
}