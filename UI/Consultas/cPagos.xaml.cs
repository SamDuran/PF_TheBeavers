using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Models;
using BLL;

namespace UI
{
    public partial class cPagos : Window
    {
        private DateTime fechaDesde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private DateTime fechaHasta = DateTime.Now;
        private string CadenaRespaldo="";
        private List<Pagos>? lista = new List<Pagos>();
        public Pagos pago = new Pagos();
        private rPagos? VentanaRegistro;
        public cPagos()
        {
            InitializeComponent();
        }
        public cPagos(rPagos Registro)
        {
            InitializeComponent();
            VentanaRegistro = Registro;
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
            CadenaRespaldo = BusquedaTB.Text;
            if(BusquedaTB.Text.Trim().Length>0)
            {
                switch(FiltroBox.SelectedIndex)
                {
                    case 0: //Buscar por ID
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                            && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = PagosBLL.GetList(e => e.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 1: //Buscar por No Contrato
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.NoContrato.Contains(BusquedaTB.Text)
                            && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = PagosBLL.GetList(e => e.NoContrato.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 2: //Buscar por TipoPago
                    {
                        var TipoPago = TipoPagosBLL.Buscar((BusquedaTB.Text));
                        if(TipoPago==null) return;
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.TipoPagoId == TipoPago.TipoPagoId
                            && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.TipoPagoId == TipoPago.TipoPagoId
                            && x.FechaPago <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.TipoPagoId == TipoPago.TipoPagoId
                            && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = PagosBLL.GetList(x => x.TipoPagoId == TipoPago.TipoPagoId);
                        }
                        break;
                    }
                    case 3: //Buscar por Monto
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                            && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = PagosBLL.GetList(e => e.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text));
                        }
                        break;
                    }
                    case 4: //Buscar por asunto de pago
                    {
                        if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.Asunto.Contains(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else if(HastaPicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.Asunto.Contains(BusquedaTB.Text)
                            && x.FechaPago <= HastaPicker.SelectedDate);
                        }
                        else if(DesdePicker.SelectedDate != null)
                        {
                            lista = PagosBLL.GetList(x => x.Asunto.Contains(BusquedaTB.Text)
                            && x.FechaPago >= DesdePicker.SelectedDate);
                        }
                        else
                        {
                            lista = PagosBLL.GetList(e => e.Asunto.Contains(BusquedaTB.Text));
                        }
                        break;
                    }
                }
            }else
            {
                lista = PagosBLL.GetList(c => c.FechaPago >= fechaDesde && c.FechaPago <= fechaHasta);
            }
            if(DesdePicker.SelectedDate !=null && HastaPicker.SelectedDate != null && FiltroBox.SelectedIndex<0)
            {
                lista = PagosBLL.GetList(c => c.FechaPago >= fechaDesde && c.FechaPago <= fechaHasta);
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
                this.pago = (Pagos)TablaDatos.SelectedItem;
                if(VentanaRegistro!=null)
				{
                    VentanaRegistro.Cargarpago(this.pago);
                    VentanaRegistro.CerrarConsulta(this);
				}else
				{
                    new rPagos(this.pago, this).Show();
				}
			}
        }
		private void PresionoTecla(object sender, KeyEventArgs e)
		{
            if (e.Key == Key.F5)
                Refrescar();

            if (e.Key == Key.Enter)
                Buscar();
		}
	}
}
