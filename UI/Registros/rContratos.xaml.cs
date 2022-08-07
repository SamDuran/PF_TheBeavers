using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Models;
using Models.Validations;
using BLL;

namespace UI
{
    public partial class rContratos : Window
    {
        private Contratos contrato = new Contratos();
        public bool HayPlanes=false;
        public rContratos() 
        {
            if(PlanesBLL.GetListExistentes(e => true).Count==0)
            {
                new MessageBoxCustom().ShowDialog("No hay planes registrados", MessageType.Warning, MessageButtons.Ok);
                this.Close();
                return;
            }
            HayPlanes = true;
            InitializeComponent();
            TipoPlanCombo.ItemsSource = PlanesBLL.GetListExistentes(e => true);
            TipoPlanCombo.SelectedValuePath = "PlanId";
            TipoPlanCombo.DisplayMemberPath = "Nombre";
            Limpiar();
        }
        public rContratos(Contratos _contrato, cContratos ConsultaAnterior) 
        {
            this.contrato = _contrato;
            InitializeComponent();
            TipoPlanCombo.DataContext = TipoPlanCombo.ItemsSource = PlanesBLL.GetListExistentes(e => true);
            TipoPlanCombo.SelectedValuePath = "PlanId";
            TipoPlanCombo.DisplayMemberPath = "Nombre";
            var confirmacion = new MessageBoxCustom("¿Desea cerrar la ventana de consultas de contratos?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if (confirmacion.DialogResult == true)
                ConsultaAnterior.Close();
            Cargar();
        }
        //------------------------------------------------------UTILIDADES--------------------------------------------------------- 
        private void Limpiar()
		{
            contrato = new Contratos();
            this.DataContext = contrato;
            TipoPlanCombo.SelectedIndex = 0;
            OcultarLabels();
            SuspendidoCB.IsChecked = false;
            NombreTB.Focus();
        }
        private void Cargar()
		{
            this.DataContext = contrato;
            TipoPlanCombo.SelectedValue = contrato.PlanId;
            SuspendidoCB.IsChecked = contrato.Estado==2;
            MostrarLabels();
        }
        private void OcultarLabels()
        {
            ContratoLabel1.Visibility = Visibility.Hidden;
            NoContratoLabel.Visibility = Visibility.Hidden;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            ContratoLabel1.Visibility = Visibility.Visible;
            NoContratoLabel.Visibility = Visibility.Visible;
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
        private void CorregirCredenciales()
        {
            NombreTB.Text = Utilities.Utilities.CorregirNombre_O_Apellido(NombreTB.Text);
            contrato.NombreCliente = Utilities.Utilities.CorregirNombre_O_Apellido(contrato.NombreCliente);
            ApellidoTB.Text = Utilities.Utilities.CorregirNombre_O_Apellido(ApellidoTB.Text);
            contrato.ApellidoCliente = Utilities.Utilities.CorregirNombre_O_Apellido(contrato.ApellidoCliente);
            if (ContratosBLL.Buscar(contrato.ContratoId) == null) //si no existe el contrato  
                contrato.FechaCreacion = DateTime.Now; //se coloca la fecha de creación

            string dia = (contrato.FechaCreacion.Day > 9) ? (contrato.FechaCreacion.Day).ToString() : "0" + contrato.FechaCreacion.Day;
            string mes = (contrato.FechaCreacion.Month > 9) ? (contrato.FechaCreacion.Month).ToString() : "0" + contrato.FechaCreacion.Month;
            int anio = contrato.FechaCreacion.Year - 2000;

            contrato.NoContrato = NombreTB.Text[0].ToString() + ApellidoTB.Text[0].ToString() + dia + mes + anio + contrato.FechaCreacion.Hour + contrato.FechaCreacion.Minute;
            contrato.FechaModificacion = DateTime.Now;
        }
        //------------------------------------------------------BOTONES------------------------------------------------------------
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            new cContratos(this).Show();
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void CancelarBTN_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxCustom("¿Está seguro que desea cancelar este contrato?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if(confirmacion.DialogResult==true)
                this.contrato.Estado = 4;
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            contrato.PlanId = (int)TipoPlanCombo.SelectedValue;
            var planSeleccionado = PlanesBLL.Buscar(contrato.PlanId);
            if(planSeleccionado!=null)
                contrato.Plan = planSeleccionado.Nombre;

            if(Validations.ValidarContrato(contrato))
            {
                CorregirCredenciales();
                contrato.PlanId=(int)TipoPlanCombo.SelectedValue;
                string resultado = "";
                if (ContratosBLL.Existe(this.contrato.ContratoId))
                    resultado = "Guardado!";
				else
                    resultado = $"Guardado!\nNo. Contrato generado: {contrato.NoContrato}";

                if(ContratosBLL.Guardar(this.contrato))
                {
                    new MessageBoxCustom().ShowDialog(resultado, MessageType.Success, MessageButtons.Ok);
                    Limpiar();
                }
                else
                {
                    resultado = "No se pudo guardar!";
                    new MessageBoxCustom().ShowDialog(resultado, MessageType.Error, MessageButtons.Ok);
                }
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxCustom("¿Está seguro que desea eliminar este contrato?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if (confirmacion.DialogResult == true)
                if (ContratosBLL.Eliminar(this.contrato.ContratoId))
                {
                    Limpiar();
                    new MessageBoxCustom().ShowDialog("Operación exitosa", MessageType.Success, MessageButtons.Ok);
                }
                else
                    new MessageBoxCustom().ShowDialog("No se pudo realizar la operación", MessageType.Error, MessageButtons.Ok);
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
		private void ActualizarEstado(object sender, RoutedEventArgs e)
		{
            if(SuspendidoCB.IsChecked != true)
                contrato.Estado = 0;
            else
                contrato.Estado = 2;
		}
	}
}
