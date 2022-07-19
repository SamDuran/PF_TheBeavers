using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Averias
    {
        [Key]
        public int AveriaId { get; set; } //Autogenerated

        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
       
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string Descripcion { get; set; } = string.Empty;
        public int TipoAveria { get; set; }
       
    }
}