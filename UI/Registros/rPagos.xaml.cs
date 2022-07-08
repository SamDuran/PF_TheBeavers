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
        public rPagos(Pagos _pago, cPagos consulta)
        {
            this.pago = _pago;
            InitializeComponent();
            this.DataContext = pago;
            TipoPagoCombo.ItemsSource = TipoPagosBLL.GetList();
            TipoPagoCombo.SelectedValuePath = "TipoPagoId";
            TipoPagoCombo.DisplayMemberPath = "NombrePago";
            if (MessageBox.Show("¿Desea cerrar la ventana de consultas de Pagos?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                consulta.Close();
            Cargar();
        }
        //---------------------------------------------------Utilidades----------------------------------------------------
        private void Limpiar()
        {
            pago = new Pagos();
            contrato = new Contratos();
            this.DataContext = pago;
            AsuntoCombo.ItemsSource = null;
            OcultarLabels();
            LimpiarDatos();
            IdContratoTb.Focus();
            TipoPagoCombo.SelectedIndex = 0;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = pago;
            TipoPagoCombo.SelectedValue = pago.TipoPagoId;
            AsuntoCombo.ItemsSource = contrato.PosibilidadesPago();
            AsuntoCombo.SelectedItem = pago.Asunto;
            ColocarDatos();
            MostrarLabels();
        }
        private void OcultarLabels()
        {
            ComentTB.IsEnabled = idPagoTb.IsEnabled = MontoTb.IsEnabled = false;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        private void ColocarDatos()
        {
            NombreTB.Text = contrato.NombreCliente;
            ApellidoTB.Text = contrato.ApellidoCliente;
            CedulaTB.Text = contrato.Cedula;
        }
        private void LimpiarDatos()
        {
            NombreTB.Text = ApellidoTB.Text = CedulaTB.Text = "";
        }
        public void Cargarpago(Pagos _pago)
		{
            var contratoAux = ContratosBLL.BuscarNoContrato(_pago.NoContrato);
            if(contratoAux!=null)
            {
                contrato = contratoAux;
            }
            this.pago = _pago;
            Cargar();
		}
        public void CerrarConsulta(cPagos c)
		{
            c.Close();
		}
        //----------------------------------------------------Botones------------------------------------------------------
        private void BuscarBTN_Click(object sander, RoutedEventArgs e)
        {
            
            cPagos consulta = new cPagos(this);
            consulta.ShowDialog();
            
        }
        private void BuscarContratoBTN_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(IdContratoTb.Text) || string.IsNullOrWhiteSpace(IdContratoTb.Text) || IdContratoTb.Text.Length<10)
            {
                MessageBox.Show("Debe ingresar un numero de contrato valido");
                return;
            }
            var contratoAux = ContratosBLL.BuscarNoContrato(IdContratoTb.Text);
            if (contratoAux != null)
            {
                contrato = contratoAux;
                ComentTB.IsEnabled= true;
                pago.NoContrato = contrato.NoContrato;
                ColocarDatos();
                AsuntoCombo.ItemsSource = contrato.PosibilidadesPago();
                AsuntoCombo.SelectedIndex = 0;
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
            pago.Asunto = (string)AsuntoCombo.SelectedItem;
            var TipoPago = TipoPagosBLL.Buscar(pago.TipoPagoId);
            if(TipoPago!=null)
                pago.TipoPago = TipoPago.NombrePago;
            if(Validations.ValidarPago(pago))
            {
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

		private void TipoPagoCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
            ColocarMonto(contrato.Estado);
            if (pago.TipoPagoId == 1)
                MontoTb.IsEnabled = true;
            else
                MontoTb.IsEnabled = false;
		}
        private void ColocarMonto(int caso)
        {
            var plan = PlanesBLL.Buscar(contrato.PlanId);
            if(plan!=null)
            {
                decimal precio = plan.Precio;
                pago.MontoPago=(double)precio;
                MontoTb.Text = precio.ToString();
            }
        }
	}
}
