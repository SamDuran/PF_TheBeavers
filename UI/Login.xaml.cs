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

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuPrincipal.Show();

        }
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
