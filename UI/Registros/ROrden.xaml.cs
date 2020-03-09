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
            
        }

        private void Limpiar()
        {
            OrdenIdTextBox.Text = "0";
            FechaDatePickerTextBox.Text = Convert.ToString(DateTime.Now);

            DetalleDataGrid.ItemsSource = new List<OrdenDetalle>();
            Actualizar();

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
                Actualizar();
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
                
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            orden.OrdenDetalle.Add(new OrdenDetalle(Convert.ToInt32(OrdenIdTextBox.Text), Convert.ToInt32(ProductoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text)));
            Actualizar();
            OrdenDetalle ordenDetalle = new OrdenDetalle();
            int cantidad = ordenDetalle.Cantidad;
            int id = ordenDetalle.ProductoId;
            ProductoBll.Calculo(id, cantidad);
            CantidadTextBox.Clear();
            ProductoIdTextBox.Clear();
            CantidadTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            Detalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            Actualizar();
        }

        private void ConsultaButton_Click(object sender, RoutedEventArgs e)
        {
            ROConsulta consulta = new ROConsulta();
            consulta.Show();
        }
    }
}
