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
        private DateTime fechaDesde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private DateTime fechaHasta = DateTime.Now;
        private List<Contratos>? lista = new List<Contratos>();
        public Contratos contrato = new Contratos();
        private bool EsParaBuscar = false;
        public cContratos()
        {
            InitializeComponent();
        }
        public cContratos(Contratos _contrato)
        {
            InitializeComponent();
            EsParaBuscar = true;
            this.contrato = _contrato;
        }
        private void BusquedaTB_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.Key == Key.Enter)
                Buscar();
		}
        private void Buscar()
        {
            if(BusquedaTB.Text.Trim().Length>0)
            {
                switch(FiltroBox.SelectedIndex)
                {
                    case 0: //Buscar por ID
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.ContratoId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 1: //Buscar por No Contrato
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.NoContrato.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 2: //Buscar por NombreCliente
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NombreCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NombreCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.NombreCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.NombreCliente.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 3: //Buscar por ApellidoCliente
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ApellidoCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ApellidoCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.ApellidoCliente.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.ApellidoCliente.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 4: //Buscar por cedula
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Cedula.Trim('-').Contains(BusquedaTB.Text.Trim('-'))
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Cedula.Trim('-').Contains(BusquedaTB.Text.Trim('-'))
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Cedula.Trim('-').Contains(BusquedaTB.Text.Trim('-'))
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.Cedula.Trim('-').Contains(BusquedaTB.Text.Trim('-')));
                        }
                        break;
                    }
                    case 5: //Buscar por Direccion
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Direccion.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Direccion.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Direccion.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.Direccion.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 6: //Buscar por Numero celular
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Celular.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Celular.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Celular.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.Celular.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 7: //Buscar por Numero Telefono
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Telefono.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Telefono.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Telefono.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.Telefono.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 8: //Buscar por Numero TelefonoRef
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(x => x.TelefonoReferencial!=null && x.TelefonoReferencial.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 9: //Buscar por Numero Plan
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Plan.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Plan.Contains(BusquedaTB.Text)
                            && x.FechaCreacion <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = ContratosBLL.GetList(x => x.Plan.Contains(BusquedaTB.Text)
                            && x.FechaCreacion >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = ContratosBLL.GetList(e => e.Plan.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                }
            }else
            {
                lista = ContratosBLL.GetList(c => c.FechaCreacion >= fechaDesde && c.FechaCreacion <= fechaHasta);
            }
            if(DesdePicker.SelectedDate !=null && HastaPicker.SelectedDate != null && FiltroBox.SelectedIndex<0)
            {
                lista = ContratosBLL.GetList(c => c.FechaCreacion >= fechaDesde && c.FechaCreacion <= fechaHasta);
            }
            
            TablaDatos.ItemsSource = lista;
        }
        private void BuscarBTN_Click(object sender, RoutedEventArgs e)
        {
            lista = null;
            Buscar();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TablaDatos.SelectedIndex >= 0)
            {
                this.contrato = (Contratos)TablaDatos.SelectedItem;
                rContratos r = new rContratos(this.contrato);
                r.Show();
                if(EsParaBuscar)
                    this.Close();
            }
        }
    }
}
