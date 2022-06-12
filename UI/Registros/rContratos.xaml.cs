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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;
using BLL;

namespace UI
{
    public partial class rContratos : Window
    {
        Contratos contrato = new Contratos();
        public rContratos()
        {
            InitializeComponent();
            Limpiar();
        }
        private void Limpiar()
		{
            contrato = new Contratos();
            this.DataContext = contrato;
            ContratoLabel1.Visibility = Visibility.Hidden;
            NoContratoLabel.Visibility = Visibility.Hidden;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void Cargar()
		{
            this.DataContext = contrato;
            ContratoLabel1.Visibility = Visibility.Visible;
            NoContratoLabel.Visibility = Visibility.Visible;
            FechaMLabel.Visibility = Visibility.Visible;
            fModifLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            var contratoAux = ContratosBLL.Buscar(contrato.ContratoId);
            if (contratoAux != null)
            {
                contrato=contratoAux;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            CorregirCredenciales();
            if (ContratosBLL.Guardar(this.contrato))
			{
                Limpiar();
                MessageBox.Show("Operación exitosa");
			}
            else
                MessageBox.Show("No se pudo completar la operación");
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ContratosBLL.Eliminar(this.contrato.ContratoId))
            {
                Limpiar();
                MessageBox.Show("Operación exitosa");
            }
            else
                MessageBox.Show("No se pudo completar la operación");
        }
        private void CorregirCredenciales()
		{
            contrato.FechaModificacion = DateTime.Now;
            contrato.NoContrato = NombreTB.Text[0].ToString() + ApellidoTB.Text[0].ToString() + contrato.FechaCreacion.Day + contrato.FechaCreacion.Month + contrato.FechaCreacion.Year;
        }
        private void IdTextBox_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.Key == Key.Enter)
                ApellidoTB.Focus();
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
	}
}
