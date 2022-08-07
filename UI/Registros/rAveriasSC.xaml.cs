using System;
using System.Collections.Generic;
using System.Drawing;
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
using BLL;
using Models;
using Models.Validations;
using Utilities;

namespace UI
{
    public partial class rAveriasSC : Window
    {
        Averias Averia = new Averias();
        public rAveriasSC()
        {
            InitializeComponent();
            this.DataContext = Averia;
            AveriasCombo.ItemsSource = AveriasBLL.GetListExistentes(e => true);
            AveriasCombo.SelectedValuePath = "AveriaId";
            AveriasCombo.DisplayMemberPath = "Nombre";

            ClientesCombo.ItemsSource = ClientesBLL.GetList(c => true);
            ClientesCombo.SelectedValuePath = "Id";
            ClientesCombo.DisplayMemberPath = "Nombre";

            TecnicoCombo.ItemsSource = TecnicosBLL.GetList(c => true);
            TecnicoCombo.SelectedValuePath = "Id";
            TecnicoCombo.DisplayMemberPath = "Nombre";

            Limpiar();
        }
        //------------------------------------------------------UTILIDADES--------------------------------------------------------- 
        private void Limpiar()
        {
            Averia = new Averias();
            this.DataContext = Averia;
            AveriasCombo.SelectedIndex = 0;
            ClientesCombo.SelectedIndex = 0;
            TecnicoCombo.SelectedIndex = 0;
            OcultarLabels();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Averia;
            AveriasCombo.SelectedValue = Averia.TipoAveriaId;
            MostrarLabels();
        }
        private void OcultarLabels()
        {
            IdAveriasTB.IsEnabled = false;
            FechaMLabel.Visibility = Visibility.Hidden;
            fModifLabel.Visibility = Visibility.Hidden;
            FechaCLabel.Visibility = Visibility.Hidden;
            fCreacionLabel.Visibility = Visibility.Hidden;
        }
        private void MostrarLabels()
        {
            IdAveriasTB.IsEnabled = true;
            FechaMLabel.Visibility = Visibility.Visible;
            fModifLabel.Visibility = Visibility.Visible;
            FechaCLabel.Visibility = Visibility.Visible;
            fCreacionLabel.Visibility = Visibility.Visible;
        }
        //------------------------------------------------------BOTONES------------------------------------------------------------
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            //Abrir ventana de busqueda
        }
        private void NuevoBTN_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarBTN_Click(object sender, RoutedEventArgs e)
        {
            Averia.ClienteId = (int)ClientesCombo.SelectedValue;
            Averia.TecnicoId = (int)TecnicoCombo.SelectedValue;
            if (AveriasBLL.Guardar(Averia))
            {
                new MessageBoxCustom().ShowDialog("Se guardó exitosamente", MessageType.Success, MessageButtons.Ok);
                Limpiar();
            }
            else
            {
                new MessageBoxCustom().ShowDialog("No se pudo guardar", MessageType.Error, MessageButtons.Ok);
            }
        }
        private void EliminarBTN_Click(object sender, RoutedEventArgs e)
        {
            if (AveriasBLL.Eliminar(Utilities.Utilities.ToInt(IdAveriasTB.Text)))
            {
                new MessageBoxCustom().ShowDialog("Se elimino exitosamente", MessageType.Success, MessageButtons.Ok);
                Limpiar();
            }
            else
            {
                new MessageBoxCustom().ShowDialog("No se pudo eliminar", MessageType.Error, MessageButtons.Ok);
            }
        }
        //------------------------------------------------------Keydowns-----------------------------------------------------------
        //------------------------------------------------------OnFocus------------------------------------------------------------
        private void IdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IdAveriasTB.Background = new SolidColorBrush(Colors.LightSeaGreen);
            IdAveriasTB.Background.Opacity = 0.5;
        }
        private void IdTextBox_GotUnfocused(object sender, RoutedEventArgs e)
        {
            IdAveriasTB.Background = new SolidColorBrush(Colors.White);
            IdAveriasTB.Background.Opacity = 0.5;
        }
    }
}

