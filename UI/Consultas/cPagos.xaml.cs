using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BLL;
using Models;

namespace UI
{
    public partial class cPagos : Window
    {
        private string CadenaRespaldo { get; set; } = "";
        private List<Pagos>? lista { get; set; } = new List<Pagos>();
        public Pagos pago { get; set; } = new Pagos();
        private rPagos? VentanaRegistro { get; set; }
        private bool ModificoAlgo { get; set; } = false;
        public cPagos()
        {
            InitializeComponent();
            FiltroBox.SelectedIndex = 0;
        }
        public cPagos(rPagos Registro)
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
            CadenaRespaldo = BusquedaTB.Text;
            if (BusquedaTB.Text.Trim().Length > 0)
            {
                switch (FiltroBox.SelectedIndex)
                {
                    case 0: //Buscar por ID
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaPago <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PagosBLL.GetListExistentes(e => e.PagoId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                            }
                            break;
                        }
                    case 1: //Buscar por No
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.NoContrato.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.NoContrato.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.NoContrato.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PagosBLL.GetListExistentes(e => e.NoContrato.ToLower().Contains(BusquedaTB.Text.ToLower()));
                            }
                            break;
                        }
                    case 2: //Buscar por Monto
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaPago <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PagosBLL.GetListExistentes(e => e.MontoPago == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text));
                            }
                            break;
                        }
                    case 3: //Buscar por Cedula
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.CedulaCliente.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago <= HastaPicker.SelectedDate && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.CedulaCliente.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PagosBLL.GetListExistentes(x => x.NoContrato.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaPago >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PagosBLL.GetListExistentes(e => e.CedulaCliente.ToLower().Contains(BusquedaTB.Text.ToLower()));
                            }
                            break;
                        }
                }
            }
            else if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate == null)
                lista = PagosBLL.GetListExistentes(e => true);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                lista = PagosBLL.GetListExistentes(c => c.FechaPago >= DesdePicker.SelectedDate && c.FechaPago <= HastaPicker.SelectedDate);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate == null)
                lista = PagosBLL.GetListExistentes(c => c.FechaPago >= DesdePicker.SelectedDate);

            if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate != null)
                lista = PagosBLL.GetListExistentes(c => c.FechaPago >= HastaPicker.SelectedDate);

            //Filtrando mas aún
            if (!string.IsNullOrEmpty(NombreTB.Text))
                lista = lista?.FindAll(c => c.NombreCliente.ToLower().Contains(NombreTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(ApellidoTB.Text))
                lista = lista?.FindAll(c => c.ApellidoCliente.ToLower().Contains(ApellidoTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(TipoPagoTB.Text))
                lista = lista?.FindAll(c => c.TipoPago.ToLower().Contains(TipoPagoTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(AsuntoTB.Text))
                lista = lista?.FindAll(c => c.Asunto.ToLower().Contains(AsuntoTB.Text.ToLower()));

            if (lista ==null || lista.Count == 0)
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
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TablaDatos.SelectedIndex >= 0)
            {
                this.pago = (Pagos)TablaDatos.SelectedItem;
                if (VentanaRegistro != null)
                {
                    VentanaRegistro.Cargarpago(this.pago);
                    VentanaRegistro.CerrarConsulta(this);
                }
                else
                {
                    new rPagos(this.pago, this).Show();
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

        private void cPagosFocus(object sender, RoutedEventArgs e)
        {
            if (ModificoAlgo)
            {
                Refrescar();
                ModificoAlgo = false;
            }
        }
    }
}
