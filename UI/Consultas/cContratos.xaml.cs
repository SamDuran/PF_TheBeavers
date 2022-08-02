using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Models;
using BLL;

namespace UI
{
    public partial class cContratos : Window
    {
        private string CadenaRespaldo { get; set; } ="";
        private List<Contratos>? lista { get; set; } = new List<Contratos>();
        public Contratos contrato { get; set; } = new Contratos();
        private rContratos? VentanaRegistro { get; set; }
        private rPagos? VentanaPagos { get; set; }
        private bool ModificoAlgo { get; set; } = false;
        public cContratos()
        {
            InitializeComponent();
            FiltroBox.SelectedIndex = 0;
        }
        public cContratos(rContratos Registro)
        {
            InitializeComponent();
            VentanaRegistro = Registro;
            FiltroBox.SelectedIndex = 0;
        }
        public cContratos(rPagos Registro)
        {
            InitializeComponent();
            VentanaPagos = Registro;
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
            if(HastaPicker.SelectedDate!=null)
                HastaPicker.SelectedDate = HastaPicker.SelectedDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);

            TablaDatos.ItemsSource = null;
            CadenaRespaldo = BusquedaTB.Text;
            if(BusquedaTB.Text.ToLower().Trim().Length>0)
            {
                switch(FiltroBox.SelectedIndex)
                {
                    case 0: //Buscar por ID
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(e => e.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 1: //Buscar por cedula
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Cedula.Replace("-","").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Cedula.Replace("-","").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Cedula.Replace("-","").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(e => e.Cedula.Replace("-","").ToLower().Contains(BusquedaTB.Text.ToLower().Replace("-","")));
                        }
                        break;
                    }
                    case 2: //Buscar por Direccion
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower())
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(e => e.Direccion.ToLower().Contains(BusquedaTB.Text.ToLower()));
                        }
                        break;
                    }
                    case 3: //Buscar por Numero celular
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Celular.Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Celular.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Celular.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower())
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(e => e.Celular.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-","")));
                        }
                        break;
                    }
                    case 4: //Buscar por Numero Telefono
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Telefono.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Telefono.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.Telefono.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(e => e.Telefono.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-","")));
                        }
                        break;
                    }
                    case 5: //Buscar por Numero TelefonoRef
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-",""))
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetListExistentes(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.ToLower().Replace("-","").Contains(BusquedaTB.Text.ToLower().Replace("-","")));
                        }
                        break;
                    }
                }
            }else if(DesdePicker.SelectedDate == null && HastaPicker.SelectedDate == null)
                lista = ContratosBLL.GetListExistentes(c => true);
            
            if(DesdePicker.SelectedDate !=null && HastaPicker.SelectedDate != null)
                lista = ContratosBLL.GetListExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate && c.FechaCreacion <= HastaPicker.SelectedDate);

            if(DesdePicker.SelectedDate !=null && HastaPicker.SelectedDate == null)
                lista = ContratosBLL.GetListExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate );
            
            if(DesdePicker.SelectedDate ==null && HastaPicker.SelectedDate != null)
                lista = ContratosBLL.GetListExistentes(c => c.FechaCreacion >= HastaPicker.SelectedDate );
            
            //Filtrando mas aún
            if(!string.IsNullOrEmpty( NoContratoTB.Text))
                lista = lista?.FindAll(c => c.NoContrato.ToLower().Contains(NoContratoTB.Text.ToLower()));
			
            if(!string.IsNullOrEmpty(PlanTB.Text))
                lista = lista?.FindAll(c => c.Plan.ToLower().Contains(PlanTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(NombreTB.Text))
                lista = lista?.FindAll(c => c.NombreCliente.ToLower().Contains(NombreTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(ApellidoTB.Text))
                lista = lista?.FindAll(c => c.ApellidoCliente.ToLower().Contains(ApellidoTB.Text.ToLower()));

            if(SoloIncluirCB.IsChecked==true)
                lista = lista?.FindAll(c => c.Estado==2);
            
            if(IncluirCB.IsChecked==false)
                lista = lista?.FindAll(c => c.Estado!=2);

            if (SoloIncluirCanCB.IsChecked == true)
                lista = lista?.FindAll(c => c.Estado == 4);

            if (IncluirCanCB.IsChecked == false)
                lista = lista?.FindAll(c => c.Estado != 4);

            if ( lista ==null || lista.Count == 0)
            {
                MessageBox.Show("No se encontraron registros");
                return;
            }
            TablaDatos.ItemsSource = lista;
        }
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            lista = null;
            Buscar();
        }
        private void PagarBTN_Click(object sander, RoutedEventArgs e)
		{
            CargarContrato2();
		}
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            CargarContrato1();
        }
        private void CargarContrato1()
		{
            if (TablaDatos.SelectedIndex >= 0)
            {
                this.contrato = (Contratos)TablaDatos.SelectedItem;
                if (VentanaRegistro != null)
                {
                    VentanaRegistro.CargarContrato(this.contrato);
                    VentanaRegistro.CerrarConsulta(this);
                }
                else
                {
                    new rContratos(this.contrato, this).Show();
                }
                ModificoAlgo = true;
                return;
            }
            MessageBox.Show("Debe selecionar un contrato.", "Consejo");
        }
        private void CargarContrato2()
        {
            if (TablaDatos.SelectedIndex >= 0)
            {
                this.contrato = (Contratos)TablaDatos.SelectedItem;
                if (VentanaPagos != null)
                {
                    VentanaPagos.CargarContrato(this.contrato);
                    VentanaPagos.CerrarConsultaContratos(this);
                }
                else
                {
                    new rPagos(this.contrato, this).Show();
                }
                ModificoAlgo = true;
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
            if(ModificoAlgo)
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
		private void CargarBTNClick(object sender, RoutedEventArgs e)
		{
            CargarContrato1();
        }
		private void Row_RightClick(object sender, MouseButtonEventArgs e)
		{
            CargarContrato2();
        }
	}
}
