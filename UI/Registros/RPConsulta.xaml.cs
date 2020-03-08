using System;
using System.Collections.Generic;
using System.Linq;
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
  
    public partial class RPConsulta : Window
    {
        public RPConsulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Producto>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ProductoBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ProductoBll.GetList(p => p.ProductoId == id);
                        break;
                    case 2://Nombre Producto
                        listado = ProductoBll.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = ProductoBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    
    }
}
