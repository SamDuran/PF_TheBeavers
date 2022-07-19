using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Tecnicos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        //public string Cedula { get; set; } = string.Empty;
        public string NoCarnet { get; set; } = string.Empty;
        //Luego areas etc etc. 
    }
}