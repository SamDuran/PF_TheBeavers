using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Models;
using Models.Validations;
using BLL;

namespace UI
{
    public partial class rAverias : Window
    {
        private Averias averias = new Averias();
        private Contratos contrato = new Contratos();
    
        public rAverias() 
        {
            InitializeComponent();
            this.DataContext = averias;
            TipoAveriaCombo.ItemsSource = TipoAveriasBLL.GetList();
            TipoAveriaCombo.SelectedValuePath = "TipoAveriaId";
            TipoAveriaCombo.DisplayMemberPath = "Nombre";
            Limpiar();
        }

        private void Limpiar()
		{
            averias = new Averias();
            this.DataContext = averias;
            TipoAveriaCombo.SelectedValue = 0;
            OcultarLabels();
        }
        private void Cargar()
		{
            this.DataContext = null;
            this.DataContext = averias;
            TipoAveriaCombo.SelectedValue = averias.TipoAveria;
          MostrarLabels();

        }

       private void OcultarLabels()
        {
            AveriaLabel1.Visibility = Visibility.Hidden;
            NoAveriaLabel.Visibility = Visibility.Hidden;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            AveriaLabel1.Visibility = Visibility.Visible;
            NoAveriaLabel.Visibility = Visibility.Visible;
            FechaMLabel.Visibility = Visibility.Visible;
            fModifLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        
        public void CargarContrato(Contratos c)
		{
            this.contrato = c;
            Cargar();
		}
        public void CerrarConsulta(cContratos c)
		{
            c.Close();
		}
      
        //------------------------------------------------------BOTONES------------------------------------------------------------
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            new cContratos().Show();
            
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void CancelarBTN_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea cancelar esta Averia?","Confirmacion",MessageBoxButton.YesNo, MessageBoxImage.Warning) ==MessageBoxResult.Yes);

        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            
            if (AveriasBLL.Guardar(averias))
            {

               MessageBox.Show("Se guardó correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                Limpiar();
            }
            else
            {
              
               MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar esta Averia?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                if (AveriasBLL.Eliminar(this.averias.AveriaId))
                {
                    Limpiar();
                    MessageBox.Show("Operación exitosa");
                }
                else
                    MessageBox.Show("No se pudo completar la operación");
           
        }
        
       
     
	}
}
