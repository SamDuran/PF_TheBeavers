using UI;
using System.Windows;
namespace PF_THEBEAVERS
{
    public partial class MainWindow : Window
    {
        public int UsuarioLogeadoId { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rContratos_Click(object sender, RoutedEventArgs e)
        {
            rContratos ContratosView = new rContratos();
            ContratosView.Show();
        }
        private void rPlanes_Click(object sender, RoutedEventArgs e)
        {
            rPlanes PlanesView = new rPlanes();
            PlanesView.Show();

        }
        private void rPagos_Click(object sender, RoutedEventArgs e)
        {
            rPagos PagosView = new rPagos();
            PagosView.Show();
        }
        private void cContratos_Click(object sender, RoutedEventArgs e)
        {
            cContratos ContratosView = new cContratos();
            ContratosView.Show();
        }
        private void cPagos_Click(object sender, RoutedEventArgs e)
        {
            cPagos PagosView = new cPagos();
            PagosView.Show();
        }

        private void CerrarSesionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar sesión?", "Volver al Login", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new Login().Show();
                this.Close();
            }
        }
    }
}
