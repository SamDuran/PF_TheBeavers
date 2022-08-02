using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BLL;
using Models;

namespace UI
{
    public partial class pContratos : Window
    {
        private string CadenaRespaldo { get; set; } = "";
        private List<Contratos>? lista { get; set; } = new List<Contratos>();
        public Contratos contrato { get; set; } = new Contratos();
        private rContratos? VentanaRegistro { get; set; }
        private bool ModificoAlgo { get; set; } = false;
        public pContratos()
        {
            InitializeComponent();
            FiltroBox.SelectedIndex = 0;
        }
        public pContratos(rContratos Registro)
        {
            InitializeComponent();
            VentanaRegistro = Registro;
            FiltroBox.SelectedIndex = 0;
        }
        private void BusquedaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Buscar();
        }
        private void Refrescar(object sander, RoutedEventArgs e)
        {
            Refrescar();
        }
        private void Refrescar()
        {
            BusquedaTB.Text = CadenaRespaldo;
            Buscar();
        }
        private void Buscar()
        {
            TablaDatos.ItemsSource = null;
            
            if(ContratosBLL.GetListNoExistentes(c => true).Count==0)
            {
                MessageBox.Show("No hay contratos en la papelera", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CadenaRespaldo = BusquedaTB.Text;
            if (BusquedaTB.Text.ToLower().Trim().Length > 0)
            {
                switch (FiltroBox.SelectedIndex)
                {
                    case 0: //Buscar por ID
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(e => e.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                            }
                            break;
                        }
                    case 1: //Buscar por cedula
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Cedula.Replace("-", "").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Cedula.Replace("-", "").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Cedula.Replace("-", "").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(e => e.Cedula.Replace("-", "").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-", "")));
                            }
                            break;
                        }
                    case 2: //Buscar por Direccion
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(e => e.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower()));
                            }
                            break;
                        }
                    case 3: //Buscar por Numero celular
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Celular.Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Celular.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Celular.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(e => e.Celular.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", "")));
                            }
                            break;
                        }
                    case 4: //Buscar por Numero Telefono
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Telefono.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Telefono.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.Telefono.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(e => e.Telefono.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", "")));
                            }
                            break;
                        }
                    case 5: //Buscar por Numero TelefonoRef
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.TelefonoReferencial != null && x.TelefonoReferencial.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.TelefonoReferencial != null && x.TelefonoReferencial.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.TelefonoReferencial != null && x.TelefonoReferencial.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", ""))
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = ContratosBLL.GetListNoExistentes(x => x.TelefonoReferencial != null && x.TelefonoReferencial.ToLower().Replace("-", "").Contains(BusquedaTB.Text.ToLower().Replace("-", "")));
                            }
                            break;
                        }
                }
            }
            else if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate == null)
                lista = ContratosBLL.GetListNoExistentes(c => true);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                lista = ContratosBLL.GetListNoExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate && c.FechaCreacion <= HastaPicker.SelectedDate);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate == null)
                lista = ContratosBLL.GetListNoExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate);

            if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate != null)
                lista = ContratosBLL.GetListNoExistentes(c => c.FechaCreacion >= HastaPicker.SelectedDate);

            //Filtrando mas aún
            if (!string.IsNullOrEmpty(NoContratoTB.Text))
                lista = lista?.FindAll(c => c.NoContrato.ToLower().Contains(NoContratoTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(PlanTB.Text))
                lista = lista?.FindAll(c => c.Plan.ToLower().Contains(PlanTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(NombreTB.Text))
                lista = lista?.FindAll(c => c.NombreCliente.ToLower().Contains(NombreTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(ApellidoTB.Text))
                lista = lista?.FindAll(c => c.ApellidoCliente.ToLower().Contains(ApellidoTB.Text.ToLower()));

            if (SoloIncluirCB.IsChecked == true)
                lista = lista?.FindAll(c => c.Estado == 2);

            if (IncluirCB.IsChecked == false)
                lista = lista?.FindAll(c => c.Estado != 2);

            if (SoloIncluirCanCB.IsChecked == true)
                lista = lista?.FindAll(c => c.Estado == 4);

            if (IncluirCanCB.IsChecked == false)
                lista = lista?.FindAll(c => c.Estado != 4);

            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("No se encontraron registros");
                return;
            }

            TablaDatos.ItemsSource = lista;
        }
        private void RestaurarContrato(Contratos contrat)
        {

            this.contrato = contrat;
            if (MessageBox.Show("¿Seguro que desea restaurar el contrato?", "Restaurar contrato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                contrato.Existente = true;
                if (ContratosBLL.Guardar(contrato))
                {
                    MessageBox.Show("Se ha restaurado el contrato");
                    Refrescar();
                }
                else
                {
                    MessageBox.Show("No se pudo restaurar el contrato");
                }
            }
        }
        private void EliminarContrato(Contratos c)
        {
            this.contrato = c;
            if (MessageBox.Show("¿Seguro que desea eliminar el contrato?", "Eliminar contrato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (ContratosBLL.EliminarPermanente(contrato.ContratoId))
                {
                    MessageBox.Show("Se ha eliminado el contrato");
                    Refrescar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el contrato");
                }
            }
        }
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            lista = null;
            Buscar();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (Contratos)TablaDatos.SelectedItem;
            if (item != null)
            {

                RestaurarContrato(item);

            }
        }
        private void Row_RightClick(object sender, MouseButtonEventArgs e)
        {
            var item = (Contratos)TablaDatos.SelectedItem;
            if (item != null)
            {

                EliminarContrato(item);

            }
        }
        private void PresionoTecla(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                Refrescar();

            if (e.Key == Key.Enter)
                Buscar();
        }
        private void WindowGotFocus(object sender, RoutedEventArgs e)
        {
            if (ModificoAlgo)
            {
                Refrescar();
                ModificoAlgo = false;
            }
        }
        private void Incluir_Checked(object sender, RoutedEventArgs e)
		{
            if(IncluirCB.IsChecked==true)
            {
                SoloIncluirCB.IsEnabled=true;
                SoloIncluirCanCB.IsChecked =false;
                SoloIncluirCanCB.IsEnabled=false;
            }
            else
            {
                SoloIncluirCB.IsEnabled=false;
                SoloIncluirCB.IsChecked=false;
            }
		}
		private void SoloIncluir_Checked(object sender, RoutedEventArgs e)
		{
            if(IncluirCB.IsChecked==true)
            {
                SoloIncluirCB.IsEnabled=true;
                SoloIncluirCanCB.IsChecked = IncluirCanCB.IsChecked = false;
                SoloIncluirCanCB.IsEnabled=false;
            }
            else
            {
                SoloIncluirCB.IsEnabled=false;
                SoloIncluirCB.IsChecked=false;
            }
		}
		private void Cancelados_Checked(object sender, RoutedEventArgs e)
		{
            if(IncluirCanCB.IsChecked==true)
            {
                SoloIncluirCanCB.IsEnabled=true;
                SoloIncluirCB.IsChecked=false;
                SoloIncluirCB.IsEnabled=false;
            }
            else
            {
                SoloIncluirCanCB.IsEnabled=false;
                SoloIncluirCanCB.IsChecked=false;
            }
		}
        private void SoloCancelados_Checked(object sender, RoutedEventArgs e)
		{
            if(IncluirCanCB.IsChecked==true)
            {
                SoloIncluirCanCB.IsEnabled=true;
                SoloIncluirCB.IsChecked = IncluirCB.IsChecked=false;
                SoloIncluirCB.IsEnabled=false;
            }
            else
            {
                SoloIncluirCanCB.IsEnabled=false;
                SoloIncluirCanCB.IsChecked=false;
            }
		}
        private void Restarurar_Click(object sender, RoutedEventArgs e)
        {
            RestaurarContrato((Contratos)TablaDatos.SelectedItem);
        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarContrato((Contratos)TablaDatos.SelectedItem);
        }
    }
}
