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
				MessageBox.Show("El campo Nombre Cliente no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.NombreCliente))
			{
				MessageBox.Show("El campo Nombre Cliente no puede contener numeros", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.ApellidoCliente)||string.IsNullOrWhiteSpace(contrato.ApellidoCliente))
			{
				MessageBox.Show("El campo Apellido Cliente no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.ApellidoCliente))
			{
				MessageBox.Show("El campo Apellido Cliente no puede contener numeros", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Cedula)||string.IsNullOrWhiteSpace(contrato.Cedula))
			{
				MessageBox.Show("El campo Cedula no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if(!CedulaValidation.IsMatch(contrato.Cedula))
			{
				MessageBox.Show("El campo Cedula no es valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Direccion))
			{
				MessageBox.Show("El campo Direccion no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Telefono))
			{
				MessageBox.Show("El campo Telefono no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if (!TelefonoValidation.IsMatch(contrato.Telefono))
			{
				MessageBox.Show("El campo Telefono no es valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Celular))
			{
				MessageBox.Show("El celular no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if(!TelefonoValidation.IsMatch(contrato.Celular))
			{
				MessageBox.Show("El campo Celular no es valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			if(contrato.PlanId == 0)
			{
				MessageBox.Show("Se debe seleccionar un plan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			return paso;
		}
	}
}
