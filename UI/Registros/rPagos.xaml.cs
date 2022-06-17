using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BLL;
using Models;
using Models.Validations;

namespace UI
{
    public partial class rPagos : Window
    {
        private Pagos pago = new Pagos();
        private Contratos contrato = new Contratos();
        public rPagos()
        {
            InitializeComponent();
            this.DataContext = pago;
            TipoPagoCombo.ItemsSource = TipoPagosBLL.GetList();
            TipoPagoCombo.SelectedValuePath = "TipoPagoId";
            TipoPagoCombo.DisplayMemberPath = "NombrePago";
            Limpiar();
        }
        //---------------------------------------------------Utilidades----------------------------------------------------
        private void Limpiar()
        {
            pago = new Pagos();
            contrato = new Contratos();
            this.DataContext = pago;
            TipoPagoCombo.SelectedIndex = 0;
            OcultarLabels();
            IdContratoTb.Focus();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = pago;
            TipoPagoCombo.SelectedValue = pago.TipoPagoId;
            MostrarLabels();
        }
        private void OcultarLabels()
        {
            idPagoTb.IsEnabled = false;
            ContratoLabel1.Visibility = Visibility.Hidden;
            NoContratoLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            ContratoLabel1.Visibility = Visibility.Visible;
            NoContratoLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        //----------------------------------------------------Botones------------------------------------------------------
        private void BuscarBTN_Click(object sander, RoutedEventArgs e)
        {
            if (this.pago.PagoId == null)
            {
                idPagoTb.IsEnabled = true;
            }
            else
            {
                if (String.IsNullOrEmpty(idPagoTb.Text) || string.IsNullOrWhiteSpace(idPagoTb.Text) || idPagoTb.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un ID de pago valido");
                    return;
                }
                var PagoAux = PagosBLL.Buscar(pago.PagoId);
                if (PagoAux != null)
                {
                    pago = PagoAux;
                    Cargar();
                }
                else
                {
                    MessageBox.Show("No se encontro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void BuscarContratoBTN_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(IdContratoTb.Text) || string.IsNullOrWhiteSpace(IdContratoTb.Text) || IdContratoTb.Text == "0")
            {
                MessageBox.Show("Debe ingresar un numero de contrato valido");
                return;
            }
            var contratoAux = ContratosBLL.Buscar(contrato.ContratoId);
            if (contratoAux != null)
            {
                contrato = contratoAux;
            }
            else
            {
                MessageBox.Show("No se encontro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NuevoBTN_Click(object sander, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sander, RoutedEventArgs e)
        {
            pago.TipoPagoId = (int)TipoPagoCombo.SelectedValue;
            if (PagosBLL.Guardar(this.pago))
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EliminarBTN_Click(object sander, RoutedEventArgs e)
        {
            if (PagosBLL.Eliminar(pago.PagoId))
            {
                MessageBox.Show("Eliminado correctamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }
        //------------------------------------------------------Keydowns-----------------------------------------------------------
        private void IdPagoTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                IdContratoTb.Focus();
        }
        private void IdConTb_KeyDown(object sender, KeyEventArgs e)
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
                TipoPagoCombo.Focus();
        }
        private void MontoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ComentTB.Focus();
        }
        //------------------------------------------------------OnFocus-----------------------------------------------------------
        private void IdPagoTB_GotFocus(object sender, RoutedEventArgs e)
        {
            idPagoTb.Background = new SolidColorBrush(Colors.LightSeaGreen);
            idPagoTb.Background.Opacity = 0.5;
        }
        private void IdPagoTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            idPagoTb.Background = new SolidColorBrush(Colors.White);
            idPagoTb.Background.Opacity = 0.5;
        }
        private void IdConTB_GotFocus(object sender, RoutedEventArgs e)
        {
            IdContratoTb.Background = new SolidColorBrush(Colors.LightSeaGreen);
            IdContratoTb.Background.Opacity = 0.5;
        }
        private void IdConTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            IdContratoTb.Background = new SolidColorBrush(Colors.White);
            IdContratoTb.Background.Opacity = 0.5;
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
        private void MontoTB_GotFocus(object sender, RoutedEventArgs e)
        {
            MontoTb.Background = new SolidColorBrush(Colors.LightSeaGreen);
            MontoTb.Background.Opacity = 0.5;
        }
        private void MontoTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            MontoTb.Background = new SolidColorBrush(Colors.White);
            MontoTb.Background.Opacity = 0.5;
        }
    }
}
