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
        Contratos? contrato = new Contratos();
        public rContratos()
        {
            InitializeComponent();
            this.DataContext = contrato;
        }
        private void Limpiar()
		{
            contrato = new Contratos();
            this.DataContext = contrato;
        }
        private void Cargar()
		{
            this.DataContext = contrato;
        }
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            var contratoAux = ContratosBLL.Buscar(contrato.ContratoId);
            if (contratoAux != null)
            {
                contrato = contratoAux;
                this.DataContext = contrato;
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
    }
}
