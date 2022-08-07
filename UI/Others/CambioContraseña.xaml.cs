
using System.Text.RegularExpressions;
using System.Windows;
using BLL;
using Models;

namespace UI
{
    public partial class CambioClave : Window
    {
        public Usuarios usuario { get; set; } = new Usuarios();
        public CambioClave(Usuarios _usuario)
        {
            usuario = _usuario;
            InitializeComponent();
            DataContext = usuario;
            UserLabel.Content = usuario.Nombre + " " + usuario.Apellido;
        }
        private void CancelarBTN_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new MessageBoxCustom("¿Estas seguro que desea cancelar?", MessageType.Confirmation, MessageButtons.YesNo);
            ventana.ShowDialog();
            if (ventana.DialogResult == true)
                Close();
        }
        private void AceptarBTN_Click(object sender, RoutedEventArgs e)
        {
            Regex validarContraseña = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}");
            if (LastPassTB.Password.Equals(usuario.Password))
            {
                if (validarContraseña.IsMatch(NewPassTB.Password))
                {
                    if (NewPassTB.Password.Equals(ConfPassTB.Password))
                    {
                        usuario.Password = NewPassTB.Password;
                        if (UsuariosBLL.Guardar(usuario))
                        {
                            new MessageBoxCustom().ShowDialog("La contraseña se ha cambiado correctamente", MessageType.Success, MessageButtons.Ok);
                            Close();
                        }
                        else
                        new MessageBoxCustom().ShowDialog("No se pudo cambiar la contraseña", MessageType.Error, MessageButtons.Ok);
                    }
                    else
                    new MessageBoxCustom().ShowDialog("Las contraseñas no coinciden", MessageType.Error, MessageButtons.Ok);
                }
                else
                new MessageBoxCustom().ShowDialog("La contraseña debe tener al menos una mayúscula, \nuna minúscula, un número y un caracter especial", MessageType.Error, MessageButtons.Ok);
            }
            else
            new MessageBoxCustom().ShowDialog("La contraseña actual no coincide", MessageType.Error, MessageButtons.Ok);
        }
    }
}
