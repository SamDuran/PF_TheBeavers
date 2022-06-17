using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
    }
}