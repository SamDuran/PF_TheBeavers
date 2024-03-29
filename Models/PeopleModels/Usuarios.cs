using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } ="";
        public string Apellido { get; set; } ="";
        public string UserName { get; set; }="";
        public string? Password { get; set; }
        public int TipoUsuarioId { get; set; }
        public string TipoUsuario { get ; set; } = "";
        public string Cedula { get; set; } = "";
        public bool Existente { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}