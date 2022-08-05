using System.Windows;
using BLL;
using Models;

namespace UI
{
    public partial class rUsuarios : Window
    {
        private Usuarios usuario { get; set; } = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            Limpiar();
        }
		//----------------------------------------- UTILS -----------------------------------------//
        private void Limpiar()
        {
            usuario = new Usuarios();
            DataContext = usuario;
			OcultarLabels();
        }
		private void Cargar()
		{
			DataContext = null;
			DataContext = usuario;
			MostrarLabels();
		}
        private void OcultarLabels()
        {
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
        }
		private void MostrarLabels()
		{
			FechaCLabel.Visibility = Visibility.Visible;
			fCreacionLabel.Visibility = Visibility.Visible;
			FechaMLabel.Visibility = Visibility.Visible;
			fModifLabel.Visibility = Visibility.Visible;
		}
        //-----------------------------------------BOTONES---------------------------------------//
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            //Abrir Consulta y seleccionar uno
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            if(usuario.UsuarioId!=0)
			{
                if(MessageBox.Show($"¿Está seguro que desea modificar el usuario {usuario.Nombres} ?", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
                    if(UsuariosBLL.Guardar(usuario))
                        MessageBox.Show("Se modificó con exito", "Operación exitosa");
					
                    else
                        MessageBox.Show("No se pudo modificar", "Operación fallida");
                }
                return;
			}else
			{
                if (UsuariosBLL.Guardar(usuario))
                    MessageBox.Show("Se guardó con exito", "Operación exitosa");

                else
                    MessageBox.Show("No se pudo guardar", "Operación fallida");
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {

        }
        //-----------------------------------------EVENTOS---------------------------------------//
        
    }
}
