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
            TipoCombo.ItemsSource = TipoUsuariosBLL.GetList();
            TipoCombo.SelectedIndex = 0;
            TipoCombo.SelectedValuePath = "Id";
            TipoCombo.DisplayMemberPath = "Tipo";
        }
		//----------------------------------------- UTILS -----------------------------------------//
        private void Limpiar()
        {
            DataContext = null;
            usuario = new Usuarios();
            DataContext = usuario;
            TipoCombo.SelectedIndex = 0;
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
            var tipoUsuario = TipoUsuariosBLL.Buscar((int)TipoCombo.SelectedValue);
            if(tipoUsuario != null)
            {
                usuario.TipoUsuarioId = tipoUsuario.Id;
                usuario.TipoUsuario = tipoUsuario.Tipo;
            }
            else
            {
                new MessageBoxCustom().ShowDialog("No se encuentra el tipo de usuario", MessageType.Warning, MessageButtons.Ok);
                return;
            }
            if(usuario.UsuarioId!=0)
			{
                var confirmacion = new MessageBoxCustom($"¿Está seguro de modificar el usuario {usuario.Nombre} ?", MessageType.Confirmation, MessageButtons.YesNo);
                confirmacion.ShowDialog();
                if(confirmacion.DialogResult==true)
				{
                    if(UsuariosBLL.Guardar(usuario))
                    {
                        new MessageBoxCustom().ShowDialog("Se modificó exitosamente", MessageType.Success, MessageButtons.Ok);
                        Limpiar();  
                    }
					
                    else
                        new MessageBoxCustom().ShowDialog("No se pudo modificar", MessageType.Error, MessageButtons.Ok);
                }
                return;
			}else
			{
                if (UsuariosBLL.Guardar(usuario))
                {
                    new MessageBoxCustom().ShowDialog("Se guardó exitosamente", MessageType.Success, MessageButtons.Ok);
                    Limpiar();
                }

                else
                    new MessageBoxCustom().ShowDialog("No se pudo guardar", MessageType.Success, MessageButtons.Ok);
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxCustom($"¿Está seguro de eliminar el usuario {usuario.Nombre} ?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if(confirmacion.DialogResult==true)
				{
                    
                    if(UsuariosBLL.Eliminar(usuario.UsuarioId))
                        new MessageBoxCustom().ShowDialog("Se eliminó exitosamente", MessageType.Success, MessageButtons.Ok);
					
                    else
                        new MessageBoxCustom().ShowDialog("No se pudo eliminar", MessageType.Error, MessageButtons.Ok);
                }
        }
        //-----------------------------------------EVENTOS---------------------------------------//
        
    }
}
