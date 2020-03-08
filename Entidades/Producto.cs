using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ordenes.Entidades
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Inventario { get; set; }



        [ForeignKey("ProductoId")]
        public virtual List<OrdenDetalle> OrdenDetalle { get; set; }

        public Producto()
        {
            ProductoId = 0;
            Nombre = string.Empty;
            Precio = 0;
            Inventario = 0;
            OrdenDetalle = new List<OrdenDetalle>();
        }
    }
}
