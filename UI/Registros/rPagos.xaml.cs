using System;
using System.Threading.Tasks;
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
        private bool PantallaCargo = false;
        public rPagos()
        {
            InitializeComponent();
            this.DataContext = pago;
            TipoPagoCombo.ItemsSource = TipoPagosBLL.GetList();
            TipoPagoCombo.SelectedValuePath = "TipoPagoId";
            TipoPagoCombo.DisplayMemberPath = "NombrePago";
            Limpiar();
            PantallaCargo = true;
            TipoPagoCombo.SelectedIndex = 1;

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
            PantallaCargo = true;
        }
        public rPagos(Contratos _contrato, cContratos consulta)
        {
            this.contrato = _contrato;
            InitializeComponent();
            this.DataContext = pago;
            TipoPagoCombo.ItemsSource = TipoPagosBLL.GetList();
            TipoPagoCombo.SelectedValuePath = "TipoPagoId";
            TipoPagoCombo.DisplayMemberPath = "NombrePago";
            if (MessageBox.Show("¿Desea cerrar la ventana de consultas?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                consulta.Close();
            ColocarDatos();
            PantallaCargo = true;

            TipoPagoCombo.SelectedIndex = 0;
            AsuntoCombo.SelectedIndex = 0;
        }


        //---------------------------------------------------Utilidades----------------------------------------------------
        private void Limpiar()
        {
            pago = new Pagos();
            contrato = new Contratos();
            this.DataContext = pago;
            TipoPagoCombo.SelectedIndex = 0;
            AsuntoCombo.ItemsSource = null;
            OcultarLabels();
            LimpiarDatos();
        }
        public void CerrarConsultaContratos(cContratos c)
        {
            c.Close();
        }
        public void CargarContrato(Contratos c)
        {
            this.contrato = c;
            ColocarDatos();
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

            ComentTB.IsEnabled = true;
            pago.NoContrato = contrato.NoContrato;
            pago.NombreCliente = contrato.NombreCliente;
            pago.ApellidoCliente = contrato.ApellidoCliente;
            pago.CedulaCliente = contrato.Cedula;
            NombreTB.Text = contrato.NombreCliente;
            ApellidoTB.Text = contrato.ApellidoCliente;
            CedulaTB.Text = contrato.Cedula;
            AsuntoCombo.ItemsSource = contrato.PosibilidadesPago();
            AsuntoCombo.SelectedIndex = 0;
            ColocarMonto(contrato.Estado);
        }
        private void LimpiarDatos()
        {
            NombreTB.Text = ApellidoTB.Text = CedulaTB.Text = "";
        }
        public void Cargarpago(Pagos _pago)
        {
            var contratoAux = ContratosBLL.BuscarNoContrato(_pago.NoContrato);
            if (contratoAux != null)
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
            cContratos consulta = new cContratos(this);
            consulta.ShowDialog();


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
            if (TipoPago != null)
                pago.TipoPago = TipoPago.NombrePago;
            if(MontoValido())
            {
                if (Validations.ValidarPago(pago))
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
            }else
            {
                MessageBox.Show("El monto no es valido!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void AsuntoCBLostFocus(object sender, RoutedEventArgs e)
        {
            pago.Asunto = (string)AsuntoCombo.SelectedItem;
            ColocarMonto(contrato.Estado);
        }
        private bool MontoValido()
        {
            var Plan = PlanesBLL.Buscar(contrato.PlanId);
            return Plan!=null && (float)Utilities.Utilities.ToDecimal(MontoTb.Text) >= Plan.Precio;
        }

        private void TipoPagoCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.PantallaCargo)
            {
                ColocarMonto(contrato.Estado);
                if (TipoPagoCombo.Items.Count > 2 && Utilities.Utilities.ToInt(TipoPagoCombo.SelectedValue.ToString()) != 0)
                {
                    var intAux = Utilities.Utilities.ToInt(TipoPagoCombo.SelectedValue.ToString());
                    var TipoPago = TipoPagosBLL.Buscar(intAux);
                    if (TipoPago != null)
                    {
                        pago.TipoPago = TipoPago.NombrePago;
                        pago.TipoPagoId = intAux;

                        if (pago.TipoPago == "Efectivo")
                            MontoTb.IsEnabled = true;
                        else
                            MontoTb.IsEnabled = false;
                    }
                }
            }
        }
        private void ColocarMonto(int caso)
        {
            var plan = PlanesBLL.Buscar(contrato.PlanId);
            if (plan != null)
            {
                var precio = CalcularMonto(plan);
                pago.MontoPago = precio;
                MontoTb.Text = precio.ToString();
            }
        }
        private float? CalcularMonto(Planes plan)
        {
            var PagoMensual = plan.Precio;
            var PagoAdelanto = PagoMensual;
            var PagoPendiente = plan.Precio + (0.2f * plan.Precio);

            if (pago.Asunto.Equals("Pagar mensualidad") || pago.Asunto.Equals("Pagar adelanto"))
                return PagoMensual;

            if (pago.Asunto.Equals("Pagar mensualidad + adelanto"))
                return PagoMensual + PagoAdelanto;

            if (pago.Asunto.Equals("Pagar monto pendiente + Pagar mensualidad + Pagar adelanto"))
                return PagoPendiente + PagoMensual + PagoAdelanto;

            if (pago.Asunto.Equals("Pagar monto pendiente + Pagar mensualidad"))
                return PagoPendiente + PagoMensual;

            if (pago.Asunto.Equals("Pagar monto pendiente"))
                return PagoPendiente;

            return 0;
        }
    }
}
