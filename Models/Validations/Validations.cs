using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Models.Validations
{
	public class Validations
	{
		public static bool ValidarContrato(Contratos contrato)
		{
			bool paso = true;
			Regex NombreValidation = new Regex(@"^[a-zA-Z]*$");
			Regex TelefonoValidation = new Regex(@"^[0-9]*$");
			Regex DireccionValidation = new Regex(@"^[a-zA-Z0-9]*$");
			Regex CedulaValidation = new Regex(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$");

			if (string.IsNullOrEmpty(contrato.NombreCliente)||string.IsNullOrWhiteSpace(contrato.NombreCliente))
			{
				MessageBox.Show("El campo Nombre Cliente no puede estar vacio");
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.NombreCliente))
			{
				MessageBox.Show("El campo Nombre Cliente no puede contener numeros");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.ApellidoCliente))
			{
				MessageBox.Show("El campo Apellido Cliente no puede estar vacio");
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.ApellidoCliente))
			{
				MessageBox.Show("El campo Apellido Cliente no puede contener numeros");
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Cedula))
			{
				MessageBox.Show("El campo Cedula no puede estar vacio");
				paso = false;
			}
			else if(!CedulaValidation.IsMatch(contrato.Cedula))
			{
				MessageBox.Show("El campo Cedula no es valido");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Direccion))
			{
				MessageBox.Show("El campo Direccion no puede estar vacio");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Telefono))
			{
				MessageBox.Show("El campo Telefono no puede estar vacio");
				paso = false;
			}
			else if (!TelefonoValidation.IsMatch(contrato.Telefono))
			{
				MessageBox.Show("El campo Telefono no es valido");
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Celular))
			{
				MessageBox.Show("El celular no puede estar vacio");
				paso = false;
			}
			else if(!TelefonoValidation.IsMatch(contrato.Celular))
			{
				MessageBox.Show("El campo Celular no es valido");
				paso = false;
			}

			return paso;
		}
	}
}
