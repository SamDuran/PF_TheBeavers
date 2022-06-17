using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoPlanes
    {
        [Key]
        public int TipoPlanId { get; set; }
        public string NombrePlan { get; set; } = string.Empty;

        public override string ToString()
        {
            return NombrePlan;
        }
    }
}