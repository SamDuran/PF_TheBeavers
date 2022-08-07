using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI;

namespace PF_THEBEAVERS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            new MessageBoxCustom().ShowDialog(e.Exception.Message, MessageType.Error, MessageButtons.Ok);

            e.Handled = true;
        }
    }
}
