using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Tecnicos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string NoCarnet { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int ZonaId { get; set; }
        public string Zona { get; set; } = string.Empty;
        public int TipoTecnicoId { get; set; }
        public string TipoTecnico { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string? Comentario;
        //Luego areas etc etc. 
    }
}