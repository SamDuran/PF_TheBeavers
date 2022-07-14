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
using System.Windows.Shapes;
using BLL;
using MaterialDesignThemes.Wpf;
using Models;
using PF_THEBEAVERS;
namespace UI
{
    public partial class Login : Window
    {

        MainWindow MenuPrincipal = new MainWindow();
        public Login()
        {
            InitializeComponent();
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
        }
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Ingresar()
        {
            var bll = new LoginBLL();
            bool paso = bll.Validar(txtUsername.Text, txtPassword.Password);


            if (paso)
            {
                int id = bll.getUsuario();
                this.Close();
                MenuPrincipal.UsuarioLogeadoId = id;
                MenuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contraseña incorrecta!", "Error!");
                txtUsername.Focus();
                txtPassword.Clear();

            }
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }
        private void IngresarKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Ingresar();
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtPassword.Focus();
        }


        private void Password_KeySign(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                IngresarButton_Click(sender, e);
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                txtUsername.Focus();
        }

        private void Username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                txtPassword.Focus();
        }


    }
}
