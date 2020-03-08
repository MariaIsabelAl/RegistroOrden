using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ordenes.BLL;
using Ordenes.Entidades;

namespace Ordenes.UI.Registros
{
    public partial class ROConsulta : Window
    {
        public ROConsulta()
        {
            InitializeComponent();

        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Orden>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = OrdenBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = OrdenBll.GetList(p => p.OrdenId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = OrdenBll.GetList(p => p.Fecha == fecha);
                        break;

                }

            }
            else
            {
                listado = OrdenBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    }
}
