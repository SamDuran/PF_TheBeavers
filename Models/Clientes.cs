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
        public int Estado { get; set; }//0=al dia, 2= retrasado, 3 =cancelado
    }
}