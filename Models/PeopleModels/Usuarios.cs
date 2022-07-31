using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoldReports.Windows.Data;

namespace Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        
        public string Nombres { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public int TipoUsuarioId { get; set; }
        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = "";
            UserName = "";
            Password = "";
        }
    }
}