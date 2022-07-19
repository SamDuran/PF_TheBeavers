using UI;
using System.Windows;
using System.Windows.Input;

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
            if(ContratosView.HayPlanes)
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

        private void rAverias_Click(object sender, RoutedEventArgs e)
        {
            rAverias AveriasView = new rAverias();
            AveriasView.Show();
        } 
        private void rAsignAverias_Click(object sender, RoutedEventArgs e)
        {
            rAveriasSC AveriasView = new rAveriasSC();
            AveriasView.Show();
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
        private void cPlanes_Click(object sender, RoutedEventArgs e)
        {
            //cPlanes PlanesView = new cPlanes();
            //PlanesView.Show();
        }
        private void pContratos_Click(object sender, RoutedEventArgs e)
        {
            pContratos ContratosView = new pContratos();
            ContratosView.Show();
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
