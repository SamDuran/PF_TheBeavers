using System.Text.RegularExpressions;
using System.Windows;
using UI;

namespace Models.Validations
{
    public class Validations
    {
        public static bool ValidarContrato(Contratos contrato)
        {
            bool paso = true;
            Regex NombreValidation = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚ ]*$");
            Regex TelefonoValidation = new Regex(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$");
            Regex DireccionValidation = new Regex(@"^[a-zA-Z0-9]*$");
            Regex CedulaValidation = new Regex(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$");//el formato debe ser: 000-0000000-0"
            string? ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(contrato.NombreCliente) || string.IsNullOrWhiteSpace(contrato.NombreCliente))
            {
                ErrorMessage += "\nEl campo Nombre Cliente no puede estar vacio";
                paso = false;
            }
            else if (!NombreValidation.IsMatch(contrato.NombreCliente))
            {
                ErrorMessage += ("\nEl campo Nombre Cliente no puede contener numeros");
                paso = false;
            }

            if (string.IsNullOrEmpty(contrato.ApellidoCliente) || string.IsNullOrWhiteSpace(contrato.ApellidoCliente))
            {
                ErrorMessage += ("\nEl campo Apellido Cliente no puede estar vacio");
                paso = false;
            }
            else if (!NombreValidation.IsMatch(contrato.ApellidoCliente))
            {
                ErrorMessage += ("\nEl campo Apellido Cliente no puede contener numeros");
                paso = false;
            }

            if (string.IsNullOrEmpty(contrato.Cedula) || string.IsNullOrWhiteSpace(contrato.Cedula))
            {
                ErrorMessage += ("\nEl campo Cedula no puede estar vacio");
                paso = false;
            }
            else if (!CedulaValidation.IsMatch(contrato.Cedula))
            {
                ErrorMessage += ("\nEl campo Cedula no es valido");
                paso = false;
            }

            if (string.IsNullOrEmpty(contrato.Direccion))
            {
                ErrorMessage += ("\nEl campo Direccion no puede estar vacio");
                paso = false;
            }

            if (string.IsNullOrEmpty(contrato.Telefono))
            {
                ErrorMessage += ("\nEl campo Telefono no puede estar vacio");
                paso = false;
            }
            else if (!TelefonoValidation.IsMatch(contrato.Telefono))
            {
                ErrorMessage += ("\nEl campo Telefono no es valido");
                paso = false;
            }

            if (string.IsNullOrEmpty(contrato.TelefonoReferencial))
            {

                return paso;
            }

            if (!TelefonoValidation.IsMatch(contrato.TelefonoReferencial))
			{
				ErrorMessage += ("\nEl campo Telefono Referencial no es valido");
				paso = false;
			}
		
            
            if (string.IsNullOrEmpty(contrato.Celular))
            {
                ErrorMessage += ("\nEl celular no puede estar vacio");
                paso = false;
            }
            else if (!TelefonoValidation.IsMatch(contrato.Celular))
            {
                ErrorMessage += ("\nEl campo Celular no es valido");
                paso = false;
            }

            if (contrato.PlanId == 0)
            {
                ErrorMessage += ("\nSe debe seleccionar un plan");
                paso = false;
            }
            if (!paso)
                new MessageBoxCustom().ShowDialog(ErrorMessage, MessageType.Error, MessageButtons.Ok);

            return paso;
        }
        public static bool ValidarPlan(Planes plan)
        {
            bool paso = true;
            Regex NombreValidation = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚ ]*$");
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(plan.Nombre) || string.IsNullOrWhiteSpace(plan.Nombre))
            {
                ErrorMessage += ("\nEl campo Nombre no puede estar vacio");
                paso = false;
            }
            else if (!NombreValidation.IsMatch(plan.Nombre))
            {
                ErrorMessage += ("\nEl campo Nombre no puede contener numeros");
                paso = false;
            }
            if (string.IsNullOrEmpty(plan.Descripcion) || string.IsNullOrWhiteSpace(plan.Descripcion))
            {
                ErrorMessage += ("\nEl campo Descripcion no puede estar vacio");
                paso = false;
            }
            if (plan.Precio <= 0)
            {
                ErrorMessage += ("\nEl campo Costo no puede estar vacio");
                paso = false;
            }
            if (!paso)
                new MessageBoxCustom().ShowDialog(ErrorMessage, MessageType.Error, MessageButtons.Ok);

            return paso;
        }
        public static bool ValidarPago(Pagos pago)
        {
            bool paso = true;
            string ErrorMessage = "";
            if (pago.TipoPagoId == 0)
            {
                ErrorMessage += ("\nSe debe seleccionar un tipo de pago");
                paso = false;
            }
            if (string.IsNullOrEmpty(pago.NoContrato))
            {
                ErrorMessage += ("\nSe debe seleccionar un contrato");
                paso = false;
            }
            if (pago.MontoPago <= 0)
            {
                ErrorMessage += ("\nEl campo Monto no puede ser 0 o menor");
                paso = false;
            }

            if (!paso)
                new MessageBoxCustom().ShowDialog(ErrorMessage, MessageType.Error, MessageButtons.Ok);

            return paso;
        }
        public static bool ValidarUsuario(Usuarios usuario)
        {
            bool paso = true;
            string ErrorMessage = "";
            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                ErrorMessage += ("\nEl campo Nombre no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrEmpty(usuario.Apellido) || string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                ErrorMessage += ("\nEl campo Apellido no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrEmpty(usuario.Cedula) || string.IsNullOrWhiteSpace(usuario.Cedula))
            {
                ErrorMessage += ("\nEl campo Cedula no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrEmpty(usuario.UserName) || string.IsNullOrWhiteSpace(usuario.UserName))
            {
                ErrorMessage += ("\nEl campo UserName no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrEmpty(usuario.Password) || string.IsNullOrWhiteSpace(usuario.Password))
            {
                ErrorMessage += ("\nEl campo Password no puede estar vacio");
                paso = false;
            }
            if (usuario.TipoUsuarioId == 0)
            {
                ErrorMessage += ("\nSe debe seleccionar un tipo de usuario");
                paso = false;
            }

            if (!paso)
                new MessageBoxCustom().ShowDialog(ErrorMessage, MessageType.Error, MessageButtons.Ok);

            return paso;
        }
    }
}
