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
			Regex NombreValidation = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚ ]*$");
			Regex TelefonoValidation = new Regex(@"^[0-9 -]*$");
			Regex DireccionValidation = new Regex(@"^[a-zA-Z0-9]*$");
			Regex CedulaValidation = new Regex(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$");//el formato debe ser: 000-0000000-0"
			string? ErrorMessage = string.Empty;

			if (string.IsNullOrEmpty(contrato.NombreCliente)||string.IsNullOrWhiteSpace(contrato.NombreCliente))
			{
				ErrorMessage+="\nEl campo Nombre Cliente no puede estar vacio";
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.NombreCliente))
			{
				ErrorMessage +=("\nEl campo Nombre Cliente no puede contener numeros");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.ApellidoCliente)||string.IsNullOrWhiteSpace(contrato.ApellidoCliente))
			{
				ErrorMessage +=("\nEl campo Apellido Cliente no puede estar vacio");
				paso = false;
			}
			else if (!NombreValidation.IsMatch(contrato.ApellidoCliente))
			{
				ErrorMessage +=("\nEl campo Apellido Cliente no puede contener numeros");
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Cedula)||string.IsNullOrWhiteSpace(contrato.Cedula))
			{
				ErrorMessage +=("\nEl campo Cedula no puede estar vacio");
				paso = false;
			}
			else if(!CedulaValidation.IsMatch(contrato.Cedula))
			{
				ErrorMessage +=("\nEl campo Cedula no es valido");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Direccion))
			{
				ErrorMessage +=("\nEl campo Direccion no puede estar vacio");
				paso = false;
			}

			if (string.IsNullOrEmpty(contrato.Telefono))
			{
				ErrorMessage +=("\nEl campo Telefono no puede estar vacio");
				paso = false;
			}
			else if (!TelefonoValidation.IsMatch(contrato.Telefono))
			{
				ErrorMessage +=("\nEl campo Telefono no es valido");
				paso = false;
			}

			if(string.IsNullOrEmpty(contrato.Celular))
			{
				ErrorMessage +=("\nEl celular no puede estar vacio");
				paso = false;
			}
			else if(!TelefonoValidation.IsMatch(contrato.Celular))
			{
				ErrorMessage +=("\nEl campo Celular no es valido");
				paso = false;
			}

			if(contrato.PlanId == 0)
			{
				ErrorMessage +=("\nSe debe seleccionar un plan");
				paso = false;
			}
			if(!paso)
				MessageBox.Show(ErrorMessage, "Er\nror", MessageBoxButton.OK, MessageBoxImage.Error);

			return paso;
		}
		public static bool ValidarPlan(Planes plan)
		{
			bool paso = true;
			Regex NombreValidation = new Regex(@"^[a-zA-Z]*$");
			
			if(string.IsNullOrEmpty(plan.Nombre)||string.IsNullOrWhiteSpace(plan.Nombre))
			{
				MessageBox.Show("El campo Nombre no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			else if(!NombreValidation.IsMatch(plan.Nombre))
			{
				MessageBox.Show("El campo Nombre no puede contener numeros", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			if(string.IsNullOrEmpty(plan.Descripcion)||string.IsNullOrWhiteSpace(plan.Descripcion))
			{
				MessageBox.Show("El campo Descripcion no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}
			if(plan.Precio <= 0)
			{
				MessageBox.Show("El campo Costo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				paso = false;
			}

			return paso;
		}
	}
}
