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
using Utilities;
using BLL;
using Models;
using Models.Validations; 

namespace UI
{
    public partial class rPlanes : Window
    {
        Planes plan = new Planes();
        private int IdPlan=0;
        public rPlanes()
        {
            InitializeComponent();
            this.DataContext=plan;
            PlanCombo .ItemsSource = TipoPlanesBLL.GetList();
            PlanCombo .SelectedValuePath = "PlanId";
            PlanCombo .DisplayMemberPath = "NombrePlan";
            Limpiar();
        }
        //------------------------------------------------------UTILIDADES--------------------------------------------------------- 
        private void Limpiar()
        {
            plan = new Planes();
            this.DataContext = plan;
            PlanCombo.SelectedIndex = 0;
            OcultarLabels();
            NombreTB.Focus();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = plan;
            PlanCombo.SelectedValue = plan.PlanId;
            EstadoCB.IsChecked = !plan.Estado;
            MostrarLabels();
        }
		private void OcultarLabels()
        {
            IdPlanTB.IsEnabled = false;
            EstadoCB.IsChecked = false;
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
            if (this.plan.PlanId == null)
            {
                IdPlanTB.IsEnabled = true;
            }
            else
            {
                if(string.IsNullOrEmpty(IdPlanTB.Text) || string.IsNullOrWhiteSpace(IdPlanTB.Text) || IdPlanTB.Text == "0")
                {
                    MessageBox.Show("Debe de ingresar un ID");
                }
                else
                {
                    var planAux = PlanesBLL.Buscar(Utilities.Utilities.ToInt(IdPlanTB.Text));
                    if (planAux != null)
                    {
                        plan = planAux;
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el plan");
                    }
                }
            }
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            plan.TipoPlanId = IdPlan;
            NombreTB.Text = Utilities.Utilities.CorregirNombre_O_Apellido(NombreTB.Text);
            if(Validations.ValidarPlan(this.plan))
            {
                if(PlanesBLL.Guardar(plan))
                {
                    MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            if (PlanesBLL.Eliminar(Utilities.Utilities.ToInt(IdPlanTB.Text)))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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
            PrecioTB.Background = new SolidColorBrush(Colors.White);
            PrecioTB.Background.Opacity = 0.5;
        }
        private void PrecioB_GotUnfocused(object sender, RoutedEventArgs e)
        {
            PrecioTB.Background = new SolidColorBrush(Colors.White);
            PrecioTB.Background.Opacity = 0.5;
        }

		private void EstadoCB_Checked(object sender, RoutedEventArgs e)
		{
            if(EstadoCB.IsChecked == true)
                plan.Estado = false;
            else
                plan.Estado = true;
            
		}
	}
}

