using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoPagos
    {
        [Key]
        public int TipoPagoId { get; set; }
        public string NombrePago { get; set; } = string.Empty;
    }
}