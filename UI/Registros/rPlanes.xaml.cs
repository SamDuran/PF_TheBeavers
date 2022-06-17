using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;
using Models.Validations;
using BLL;

namespace UI
{
    public partial class rPlanes : Window
    {
        TipoPlanes planes = new TipoPlanes();
        public rPlanes()
        {
            InitializeComponent();
            
        }
        //------------------------------------------------------UTILIDADES--------------------------------------------------------- 
        private void Limpiar()
        {
            
        }
        private void Cargar()
        {
          
        }
        private void OcultarLabels()
        {
            IdPlanTB.IsEnabled = false;
        
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            IdPlanTB.IsEnabled = true;
            FechaMLabel.Visibility = Visibility.Visible;
            fModifLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        //------------------------------------------------------BOTONES------------------------------------------------------------
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void CorregirCredenciales()
        {
           
        }
        //------------------------------------------------------Keydowns-----------------------------------------------------------
        private void IdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                NombreTB.Focus();
        }
        private void NombreTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PrecioTB.Focus();
        }

        
      
        //------------------------------------------------------OnFocus------------------------------------------------------------
        private void IdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IdPlanTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            IdPlanTB.Background.Opacity = 0.5;
        }
        private void IdTextBox_GotUnfocused(object sender, RoutedEventArgs e)
        {
            IdPlanTB.Background = new SolidColorBrush(Colors.White);
            IdPlanTB.Background.Opacity = 0.5;
        }
        private void NombreTB_GotFocus(object sender, RoutedEventArgs e)
        {
            NombreTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            NombreTB.Background.Opacity = 0.5;
        }
        private void NombreTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            NombreTB.Background = new SolidColorBrush(Colors.White);
            NombreTB.Background.Opacity = 0.5;
        }

        private void PrecioTB_GotFocus(object sender, RoutedEventArgs e)
        {
            PrecioTB.Background = new SolidColorBrush(Colors.White);
            PrecioTB.Background.Opacity = 0.5;
        }

        private void PrecioB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            PrecioTB.Background = new SolidColorBrush(Colors.White);
            PrecioTB.Background.Opacity = 0.5;
        }


       
    }
}

