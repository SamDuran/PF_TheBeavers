using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoTecnicos
    {
        [Key]
        public int Id { get; set; }// 1 FibraOptica, 2 averias, 3 general 
        public string Tipo { get; set; } = string.Empty;
    }
}