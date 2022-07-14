using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public string NoContrato {get;set;}=string.Empty;
        public int TipoPagoId { get; set; }//Si es tarjeta, cheque, etc.
        public string TipoPago { get; set; } = string.Empty;//Si es tarjeta, cheque, etc.
        public double MontoPago { get; set; }
        public string Asunto { get; set; } = string.Empty;// Si es solo pago de mensualidad, o reactivación etc etc
        public string Comentario { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; } = DateTime.Now;// fecha del pago 
    }
}