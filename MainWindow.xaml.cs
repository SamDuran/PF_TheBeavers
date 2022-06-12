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
using UI;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void Registros_Click(object sender, RoutedEventArgs e)
		{
            rContratos ContratosView = new rContratos();
            ContratosView.Show();
		}
        private void Consultas_Click(object sender, RoutedEventArgs e)
        {
            cContratos ContratosView = new cContratos();
            ContratosView.Show();
        }
    }
}
