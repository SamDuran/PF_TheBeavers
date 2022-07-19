using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoAverias
    {
        [Key]
        public int TipoAveriaId { get; set; }
        public string NombreAveria { get; set; } = string.Empty;

        public override string ToString()
        {
            return NombreAveria;
        }
    }
}