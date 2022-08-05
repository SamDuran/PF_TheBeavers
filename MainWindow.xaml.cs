using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using iText.Kernel.Pdf;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using Models;
using UI;

namespace PF_THEBEAVERS
{
    public partial class MainWindow : Window
    {
        public Usuarios UsuarioLogeado { get; set; } = new Usuarios();
        public MainWindow(Usuarios? _usuario)
        {
            if (_usuario != null)
                UsuarioLogeado = _usuario;

            InitializeComponent();
            MainMenu.Items.Remove(Reportes);
            DataContext = UsuarioLogeado;
            ProfileMenuItem.Header = "Bienvenid@: " + UsuarioLogeado.Nombres;

            if (UsuarioLogeado.TipoUsuarioId == 1)//si es admin
                AddAdminOptions();
            else if (UsuarioLogeado.TipoUsuarioId == 3)//si es empleado de call center
                PutJustCallCenterOptions();

            AddUserToTitle();
        }
        private void AddAdminOptions()
        {
            var rUsers = new MenuItem()
            {
                Header = "Usuarios",
                Icon = new System.Windows.Controls.Image()
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Users.png"))
                },
                Tag = "Usuarios",
                ToolTip = "Registro de Usuarios",
                Name = "rUsuarios",

            };
            rUsers.Click += rUsuarios_Click;
            Registros.Items.Add(rUsers);

            var rTecnico = new MenuItem()
            {
                Header = "Tecnicos",
                Icon = new System.Windows.Controls.Image()
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/tecnico.png"))
                },
                Tag = "Tecnicos",
                ToolTip = "Registro de Tecnicos",
                Name = "Tecnicos",
            };
            rTecnico.Click += rTecnico_Click;
            rTecnico.IsEnabled = false;
            Registros.Items.Add(rTecnico);

            var cUsers = new MenuItem()
            {
                Header = "Usuarios",
                Icon = new System.Windows.Controls.Image()
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Users.png"))
                },
                Tag = "Usuarios",
                ToolTip = "Consulta de Usuarios",
                Name = "rUsuarios",
            };
            cUsers.Click += cUsuarios_Click;
            cUsers.IsEnabled = false;
            Consultas.Items.Add(cUsers);

            var cTecnico = new MenuItem()
            {
                Header = "Tecnicos",
                Icon = new System.Windows.Controls.Image()
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/tecnico.png"))
                },
                Tag = "Tecnicos",
                ToolTip = "Consulta de Tecnicos",
                Name = "Tecnicos",
            };
            cTecnico.Click += cTecnico_Click;
            cTecnico.IsEnabled = false;
            Consultas.Items.Add(cTecnico);
        }
        private void PutJustCallCenterOptions()
        {
            Registros.Items.Remove(mPlanes);//elimina el item de registro de planes
            Registros.Items.Remove(mContratos); //elimina el item de registro de Contratos
            Registros.Items.Remove(mPagos);//elimina el item de registro de Pagos
            Registros.Items.Remove(mAverias);//elimina el item de registro de asignacion de averias
            Consultas.Items.Remove(cPlanes);//elimina el item de consulta de planes
            Consultas.Items.Remove(cContratos); //elimina el item de consulta de Contratos
            Consultas.Items.Remove(cPagos);//elimina el item de consulta de Pagos
        }
        private void AddUserToTitle()
        {
            string TipoUsuario;
            if (UsuarioLogeado.TipoUsuarioId == 1)
                TipoUsuario = "Administrador";
            else if (UsuarioLogeado.TipoUsuarioId == 2)
                TipoUsuario = "Empleado común";
            else
                TipoUsuario = "Call Center";
            Main.Title = $"{Main.Title} - {UsuarioLogeado.Nombres} : {TipoUsuario}";
        }
        private void CambiarClave_Click(object sander, RoutedEventArgs e)
        {
            new CambioClave(UsuarioLogeado).ShowDialog();
        }
        private void rUsuarios_Click(object sander, RoutedEventArgs e)
        {
            new rUsuarios().Show();
        }
        private void cUsuarios_Click(object sander, RoutedEventArgs e)
        {
            //new cUsuarios().Show();
        }
        private void rTecnico_Click(object sander, RoutedEventArgs e)
        {
            //new rTecnico().Show();
        }
        private void cTecnico_Click(object sander, RoutedEventArgs e)
        {
            //new cTecnico().Show();
        }
        private void rContratos_Click(object sender, RoutedEventArgs e)
        {
            rContratos ContratosView = new rContratos();
            if (ContratosView.HayPlanes)
                ContratosView.Show();
        }
        private void rPlanes_Click(object sender, RoutedEventArgs e)
        {
            new rPlanes().Show();

        }
        private void rPagos_Click(object sender, RoutedEventArgs e)
        {
            new rPagos().Show();
        }
        private void rAverias_Click(object sender, RoutedEventArgs e)
        {
            new rAverias().Show();
        }
        private void rAsignAverias_Click(object sender, RoutedEventArgs e)
        {
            new rAveriasSC().Show();
        }
        private void cContratos_Click(object sender, RoutedEventArgs e)
        {
            new cContratos().Show();
        }
        private void cPagos_Click(object sender, RoutedEventArgs e)
        {
            new cPagos().Show();
        }
        private void cPlanes_Click(object sender, RoutedEventArgs e)
        {
            new cPlanes().Show();
        }
        private void pContratos_Click(object sender, RoutedEventArgs e)
        {
            pContratos ContratosView = new pContratos();
            ContratosView.Show();
        }
        private void repContratos_Click(object sender, RoutedEventArgs e)
        {
            //Implementar reportes
            var dialog = new FolderBrowserDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Description = "Selecciona una carpeta donde guardar el reporte"; // instead of default "Save As"
            dialog.ShowDialog();
            if(dialog.SelectedPath == "")
                return;
            
            string ruta = dialog.SelectedPath+$"/R_Contratos #{DateTime.Now.ToString("dd-mm-yyyy")}.pdf";

            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            document.Add(new Paragraph("Reporte de Contratos"));
            document.Close();
            System.Windows.MessageBox.Show("Reporte generado correctamente", "Reporte", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CerrarSesionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Está seguro que desea cerrar sesión?", "Volver al Login", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new Login().Show();
                Close();
            }
        }
    }
}
