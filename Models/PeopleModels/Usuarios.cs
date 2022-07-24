using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        
        public string Nombres { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public TipoUsuarios TipoUsuario { get; set; } = new TipoUsuarios();
        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = "";
            UserName = "";
            Password = "";
        }
    }
}