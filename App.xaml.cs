using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PF_THEBEAVERS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ha Ocurrido una excepción\n" + e.Exception.Message, "Excepción", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}
