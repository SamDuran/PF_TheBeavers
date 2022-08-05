
using System.Windows;
using Models;
using BLL;

namespace UI
{
	public partial class CambioClave : Window
	{
		public Usuarios usuario { get; set; } = new Usuarios();
		public CambioClave(Usuarios _usuario)
		{
			usuario = _usuario;
			InitializeComponent();
		}

		private void CancelarBTN_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("¿Está seguro que desea cancelar?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				Close();
		}

		private void AceptarBTN_Click(object sender, RoutedEventArgs e)
		{
			if(NewPassTB.Password==ConfPassTB.Password)
			{
				if (MessageBox.Show("¿Está seguro que desea modificar su contraseña?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					usuario.Password = NewPassTB.Password;
					UsuariosBLL.Guardar(usuario);
					Close();
				}
			}
			else
			{
				MessageBox.Show("La contraseña de confirmación no coincide","Error");
			}
		}
	}
}
