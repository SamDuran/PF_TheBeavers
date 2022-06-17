using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Pagos
    {
        [Key]
        public int? PagoId { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;
        public double MontoPago { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public string Comentario { get; set; } = string.Empty;
        public int TipoPagoId { get; set; }
    }
}