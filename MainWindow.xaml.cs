using System;
using System.Collections.Generic;
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
using Ordenes.Entidades;
using Ordenes.UI.Registros;

namespace Ordenes
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void ProductoButton_Click(object sender, RoutedEventArgs e)
        {
            RProducto rProducto = new RProducto();
            rProducto.Show();
        }

        private void OrdenButton_Click(object sender, RoutedEventArgs e)
        {
            ROrden rOrden = new ROrden();
            rOrden.Show();
        }
    }
}
