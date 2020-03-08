using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ordenes.Entidades
{
    public class OrdenDetalle
    {
        [Key]
        public int OrdenDetalleId { get; set; }
        public int ProductoId { get; set; }
        public int OrdenId { get; set; }
        public string Cantidad { get; set; }

        public OrdenDetalle()
        {
            OrdenDetalleId = 0;
            ProductoId = 0;
            OrdenId = 0;
            Cantidad = string.Empty;
        }


    }
}
