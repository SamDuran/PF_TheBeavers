using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BLL;
using Models;

namespace UI
{
    public partial class cPlanes : Window
    {
        public Planes plan { get; set; } = new Planes();
        public string CadenaRespaldo { get; set; } = "";
        public rPlanes? VentanaRegistro { get; set; }
        public bool ModificoAlgo { get; set; } = false;
        private List<Planes>? lista { get; set; } = new List<Planes>();

        public cPlanes()
        {
            InitializeComponent();
            FiltroBox.SelectedIndex = 0;
        }

        public cPlanes(rPlanes Registro)
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
            if(HastaPicker.SelectedDate!=null)
                HastaPicker.SelectedDate = HastaPicker.SelectedDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
            
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
                                lista = PlanesBLL.GetListExistentes(x => x.PlanId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.PlanId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.PlanId == Utilities.Utilities.ToInt(BusquedaTB.Text)
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PlanesBLL.GetListExistentes(e => e.PlanId == Utilities.Utilities.ToInt(BusquedaTB.Text));
                            }
                            break;
                        }
                    case 1: //Buscar por Precio
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.Precio == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.Precio == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.Precio == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text)
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PlanesBLL.GetListExistentes(e => e.Precio == (double)Utilities.Utilities.ToDecimal(BusquedaTB.Text));
                            }
                            break;
                        }
                    case 2: //Buscar por Tipo Plan
                        {
                            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.TipoPlan.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion <= HastaPicker.SelectedDate && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else if (HastaPicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.TipoPlan.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion <= HastaPicker.SelectedDate);
                            }
                            else if (DesdePicker.SelectedDate != null)
                            {
                                lista = PlanesBLL.GetListExistentes(x => x.TipoPlan.ToLower().Contains(BusquedaTB.Text.ToLower())
                                && x.FechaCreacion >= DesdePicker.SelectedDate);
                            }
                            else
                            {
                                lista = PlanesBLL.GetListExistentes(e => e.TipoPlan.ToLower().Contains(BusquedaTB.Text.ToLower()));
                            }
                            break;
                        }
                    
                }
            }

            else if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate == null)
                lista = PlanesBLL.GetListExistentes(e => true);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate != null)
                lista = PlanesBLL.GetListExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate && c.FechaCreacion <= HastaPicker.SelectedDate);

            if (DesdePicker.SelectedDate != null && HastaPicker.SelectedDate == null)
                lista = PlanesBLL.GetListExistentes(c => c.FechaCreacion >= DesdePicker.SelectedDate);

            if (DesdePicker.SelectedDate == null && HastaPicker.SelectedDate != null)
                lista = PlanesBLL.GetListExistentes(c => c.FechaCreacion >= HastaPicker.SelectedDate);

            //Filtrando mas aún
            if (!string.IsNullOrEmpty(NombreTB.Text))
                lista = lista?.FindAll(c => c.Nombre.ToLower().Contains(NombreTB.Text.ToLower()));

            if (!string.IsNullOrEmpty(DescripcionTB.Text))
                lista = lista?.FindAll(c => c.Descripcion.ToLower().Contains(DescripcionTB.Text.ToLower()));

            if (lista == null || lista.Count == 0)
            {
                new MessageBoxCustom().ShowDialog("No se encontraron registros", MessageType.Info, MessageButtons.Ok);
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
                this.plan = (Planes)TablaDatos.SelectedItem;
                if (VentanaRegistro != null)
                {
                    VentanaRegistro.Cargarplan(this.plan);
                    VentanaRegistro.CerrarConsulta(this);
                }
                else
                {
                    new rPlanes(this.plan, this).Show();
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

        private void cPlanesFocus(object sender, RoutedEventArgs e)
        {
            if (ModificoAlgo)
            {
                Refrescar();
                ModificoAlgo = false;
            }
        }
    }
}