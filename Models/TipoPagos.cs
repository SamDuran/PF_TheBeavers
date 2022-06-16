using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoPagos
    {
        [Key]
        public int TipoPagoId { get; set; }
       
        [Required]
        [Display(Name = "Tipo de pago")] //Tarjeta, efectivo, cheque
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string NombrePago { get; set; } = string.Empty;

            
         [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }


        
    }
    
}