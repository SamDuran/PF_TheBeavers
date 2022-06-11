using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
	public class Contratos
	{
		[Key]
		public int ContratoId { get; set; }
		public string NoContrato{ get; set; } = string.Empty;
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;

		[Required]
		public string? NombreCliente { get; set; }

		[Required]
		public string? ApellidoCliente { get; set; }

		[Required]
		public string? Cedula { get; set; }

		[Required]
		public string? Direccion { get; set; }

		[Required]
		public string? Celular { get; set; }

		[Required]
		public string? Telefono { get; set; }

		[Required]
		public string? TelefonoReferencial { get; set; }

		public int? TipoPlan { get; set; }

		public string? Comentario { get; set; }

	}
}