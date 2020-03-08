using Ordenes.Entidades;
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
using Ordenes.UI.Registros;

namespace Ordenes.UI.Registros
{
    
    public partial class ROrden : Window
    {
        public List<OrdenDetalle> Detalle { get; set; }
        Orden orden = new Orden();
       
        public ROrden()
        {
            InitializeComponent();
            this.DataContext = orden;
            OrdenIdTextBox.Text = "0";
            this.Detalle = new List<OrdenDetalle>();
        }

        private void Limpiar()
        {
            OrdenIdTextBox.Text = string.Empty;
            FechaDatePickerTextBox.Text = Convert.ToString(DateTime.Now);

            this.Detalle = new List<OrdenDetalle>();
            CargarGrid();

        }

        private void CargarGrid()
        {
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = this.Detalle;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            
            bool paso = false;

            if (string.IsNullOrWhiteSpace(OrdenIdTextBox.Text) || OrdenIdTextBox.Text == "0")
                paso = OrdenBll.Guardar(orden);
            else
            {
                if (!ExisteBD())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = OrdenBll.Modificar(orden);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ExisteBD()
        {
            orden = OrdenBll.Buscar(Convert.ToInt32(OrdenIdTextBox.Text));

            return (orden != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = orden;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(OrdenIdTextBox.Text);

            Limpiar();

            if (OrdenBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(OrdenIdTextBox.Text, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Orden anterior = OrdenBll.Buscar(Convert.ToInt32(OrdenIdTextBox.Text));

            if (anterior != null)
            {
                orden = anterior;
                CargarGrid();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
                
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            RProducto rProducto = new RProducto();
            if (DetalleDataGrid.ItemsSource != null)
                this.Detalle = (List<OrdenDetalle>)DetalleDataGrid.ItemsSource;

            this.Detalle.Add(new OrdenDetalle
            {
                OrdenId = Convert.ToInt32(OrdenIdTextBox.Text),
                ProductoId = Convert.ToInt32(rProducto.ProductoIdTextBox.Text),
                Cantidad = CantidadTextBox.Text


            });
            CargarGrid();
            int cantidad = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(rProducto.ProductoIdTextBox.Text);
            ProductoBll.Calculo(id, cantidad);
            CantidadTextBox.Focus();
            CantidadTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            Detalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            CargarGrid();
        }
    }
}
