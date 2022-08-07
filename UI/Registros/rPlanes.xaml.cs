using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using Models;
using Models.Validations;
using Utilities;

namespace UI
{
    public partial class rPlanes : Window
    {
        Planes plan = new Planes();
        private Contratos contrato = new Contratos();
        public rPlanes()
        {
            InitializeComponent();
            this.DataContext = plan;
            PlanCombo.ItemsSource = TipoPlanesBLL.GetList();
            PlanCombo.SelectedValuePath = "TipoPlanId";
            PlanCombo.DisplayMemberPath = "NombrePlan";
            Limpiar();
            PlanCombo.SelectedIndex = 0;
        }
        public rPlanes(Planes _plan, cPlanes consulta)
        {
            this.plan = _plan;
            InitializeComponent();
            this.DataContext = plan;
            PlanCombo.ItemsSource = TipoPlanesBLL.GetList();
            PlanCombo.SelectedValuePath = "TipoPlanId";
            PlanCombo.DisplayMemberPath = "NombrePlan";
            var confirmacion = new MessageBoxCustom("¿Desea cerrar la ventana de consultas de pagos?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if (confirmacion.DialogResult == true)
                consulta.Close();
            Cargar();
        }

        public rPlanes(Contratos _contrato, cContratos consulta)
        {
            this.contrato = _contrato;
            InitializeComponent();
            this.DataContext = plan;
            PlanCombo.ItemsSource = TipoPlanesBLL.GetList();
            PlanCombo.SelectedValuePath = "TipoPagoId";
            PlanCombo.DisplayMemberPath = "NombrePago";
            var confirmacion = new MessageBoxCustom("¿Desea cerrar la ventana de consultas?", MessageType.Confirmation, MessageButtons.YesNo);
            confirmacion.ShowDialog();
            if (confirmacion.DialogResult == true)
                consulta.Close();
            ColocarDatos();

            PlanCombo.SelectedIndex = 0;
        }
        //------------------------------------------------------UTILIDADES--------------------------------------------------------- 
        private void Limpiar()
        {
            plan = new Planes();
            this.DataContext = plan;
            PlanCombo.SelectedIndex = 0;
            EstadoCB.IsChecked = false;
            OcultarLabels();
            NombreTB.Focus();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = plan;
            PlanCombo.SelectedValue = plan.TipoPlanId;

            EstadoCB.IsChecked = !plan.Estado;
            MostrarLabels();
        }
        private void OcultarLabels()
        {
            
            EstadoCB.IsChecked = false;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            
            FechaMLabel.Visibility = Visibility.Visible;
            fModifLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }

        private void ColocarDatos()
        {

            ComentTB.IsEnabled = true;
            plan.Nombre = contrato.NombreCliente;
            NombreTB.Text = contrato.NombreCliente;
        }
        //------------------------------------------------------BOTONES------------------------------------------------------------

        public void Cargarplan(Planes _plan)
        {
            var contratoAux = ContratosBLL.Buscar(_plan.PlanId);
            if (contratoAux != null)
            {
                contrato = contratoAux;
            }
            this.plan = _plan;
            Cargar();
        }
        public void CerrarConsulta(cPlanes c)
        {
            c.Close();
        }

        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            new cPlanes(this).ShowDialog();
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            plan.TipoPlanId = (int)PlanCombo.SelectedValue;
            var TipoDePlan = TipoPlanesBLL.Buscar(plan.TipoPlanId);
            if (TipoDePlan != null)
            {
                plan.TipoPlan = TipoDePlan.NombrePlan;
                NombreTB.Text = Utilities.Utilities.CorregirNombre_O_Apellido(NombreTB.Text);
                if (Validations.ValidarPlan(this.plan))
                {
                    if (PlanesBLL.Guardar(plan))
                    {
                        new MessageBoxCustom().ShowDialog("Se guardó exitosamente", MessageType.Success, MessageButtons.Ok);
                        Limpiar();
                    }
                    else
                    {
                        new MessageBoxCustom().ShowDialog("No se pudo guardar", MessageType.Error, MessageButtons.Ok);
                    }
                }
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            if (PlanesBLL.Eliminar(Utilities.Utilities.ToInt(IdPlanTB.Text)))
            {
                new MessageBoxCustom().ShowDialog("Se eliminó exitosamente", MessageType.Success, MessageButtons.Ok);
                Limpiar();
            }
            else
            {
                new MessageBoxCustom().ShowDialog("No se pudo eliminar", MessageType.Error, MessageButtons.Ok);
            }
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
            PrecioTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            PrecioTB.Background.Opacity = 0.5;
        }
        private void PrecioTB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            PrecioTB.Background = new SolidColorBrush(Colors.White);
            PrecioTB.Background.Opacity = 0.5;
        }
        private void EstadoCB_Checked(object sender, RoutedEventArgs e)
        {
            if (EstadoCB.IsChecked == true)
                plan.Estado = false;
            else
                plan.Estado = true;

        }
    }
}

