using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
	public class Contratos
	{
		[Key]
		public int? ContratoId { get; set; }
		public string NoContrato{ get; set; } = string.Empty; //AutoGenerated
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;
		public string NombreCliente { get; set; } = string.Empty;
		public string ApellidoCliente { get; set; } = string.Empty;
		public string Cedula { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public string Celular { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string? TelefonoReferencial { get; set; }
		public int PlanId { get; set; }
		public string Plan { get; set; } = string.Empty;
		public string? Comentario { get; set; }
		public int Estado { get; set; }//0=al dia, 1= retrasado (pago del mes anterior + mora), 2 =Suspendido por el cliente, 3=suspendido por mora, 4=cancelado
		//cancelado: el contrato es cancelado por x motivo
		//suspendido por mora: el contrato es suspendido por mora
		//suspendido por el cliente: el contrato es suspendido por el cliente
		//retrasado: el pago del contrato es retrasado
		//al dia: el pago del contrato esta al dia
		public int UltimoPagoId { get; set; } //Id del ultimo pago realizado
		public int UsuarioId { get; set; } //Quien creo el contrato
		public bool Existente { get; set; } = true; //si el contrato existe en la base de datos o no

		public string[] PosibilidadesPago()
		{
			
			//Al dia
			if(Estado==0)
				return new string[] {"Pagar mensualidad", "Pagar adelanto", "Pagar mensualidad + adelanto"};

			//Retrasado 
			else if(Estado==1)
				return new string[] { "Pagar monto pendiente", "pagar monto pendiente + Pagar mensualidad",
					"Pagar monto pendiente + Pagar mensualidad + Pagar adelanto" };//Mora 20% del precio de la mensualidad

			//Suspendido por el cliente
			else if(Estado==2)
				return new string[] { "Pagar monto pendiende" };//monto pendiente = Dias consumidos; Dias consumidos= precioPlan / 30 

				//suspendido por mora
			else if(Estado==3)
				return new string[] { "Pagar monto pendiente", "Pagar monto pendiente + Mensualidad" };
				//Mora 20% del precio; mensualidad hare referencia al mes que se debe pagar (el mes pasado que la factura está generada)

			//Cancelado
			else
				return new string[] { "NO SE PUEDE PAGAR. CONTRATO CANCELADO" }; 
		}
	}
}