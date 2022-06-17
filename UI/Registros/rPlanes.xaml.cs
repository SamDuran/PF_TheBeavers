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
            IdContratoTB.IsEnabled = false;
            ContratoLabel1.Visibility = Visibility.Hidden;
            NoContratoLabel.Visibility = Visibility.Hidden;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            IdContratoTB.IsEnabled = true;
            ContratoLabel1.Visibility = Visibility.Visible;
            NoContratoLabel.Visibility = Visibility.Visible;
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
                ApellidoTB.Focus();
        }
        private void ApellidoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CedulaTB.Focus();
        }
        private void CedulaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                DireccionTB.Focus();
        }
        private void DirTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CelTB.Focus();
        }
        private void CelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TelTB.Focus();
        }
        private void TelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TelRefTB.Focus();
        }
        private void TelRBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TipoPlanCombo.Focus();
        }
        //------------------------------------------------------OnFocus------------------------------------------------------------
        private void IdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IdContratoTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            IdContratoTB.Background.Opacity = 0.5;
        }
        private void IdTextBox_GotUnfocused(object sender, RoutedEventArgs e)
        {
            IdContratoTB.Background = new SolidColorBrush(Colors.White);
            IdContratoTB.Background.Opacity = 0.5;
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
        private void ApellidoTB_GotFocus(object sender, RoutedEventArgs e)
        {
            ApellidoTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            ApellidoTB.Background.Opacity = 0.5;
        }
        private void ApellidoTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            ApellidoTB.Background = new SolidColorBrush(Colors.White);
            ApellidoTB.Background.Opacity = 0.5;
        }
        private void CedulaTB_GotFocus(object sender, RoutedEventArgs e)
        {
            CedulaTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            CedulaTB.Background.Opacity = 0.5;
        }
        private void CedulaTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            CedulaTB.Background = new SolidColorBrush(Colors.White);
            CedulaTB.Background.Opacity = 0.5;
        }
        private void DirTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DireccionTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            DireccionTB.Background.Opacity = 0.5;
        }
        private void DirTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            DireccionTB.Background = new SolidColorBrush(Colors.White);
            DireccionTB.Background.Opacity = 0.5;
        }
        private void TelTB_GotFocus(object sender, RoutedEventArgs e)
        {
            TelTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            TelTB.Background.Opacity = 0.5;
        }
        private void TelTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            TelTB.Background = new SolidColorBrush(Colors.White);
            TelTB.Background.Opacity = 0.5;
        }
        private void CelTB_GotFocus(object sender, RoutedEventArgs e)
        {
            CelTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            CelTB.Background.Opacity = 0.5;
        }
        private void CelTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            CelTB.Background = new SolidColorBrush(Colors.White);
            CelTB.Background.Opacity = 0.5;
        }
        private void TelRTB_GotFocus(object sender, RoutedEventArgs e)
        {
            TelRefTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            TelRefTB.Background.Opacity = 0.5;
        }
        private void TelRTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            TelRefTB.Background = new SolidColorBrush(Colors.White);
            TelRefTB.Background.Opacity = 0.5;
        }
    }
}

