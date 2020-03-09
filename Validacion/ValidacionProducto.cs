using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;

namespace Ordenes.Validacion
{
    public class ValidacionProducto : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Mensaje = value as string;
            if (Mensaje != null)
            {
                if (Mensaje.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Nombre");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un Nombre");
        }


    }

    public class ValidacionPrecio : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int precio = 0;
                try
                {
                    precio = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "El Precio debe ser un numero");
                }

                if (precio >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El Precio debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner un Precio");
        }
    }

    public class ValidacionInventario : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int inventario = 0;
                try
                {
                    inventario = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "El inventario debe ser un numero");
                }

                if (inventario >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El inventario debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner un inventario");
        }
    }

    public class ValidacionFecha : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if (fecha > DateTime.Now)
                    return new ValidationResult(false, "Debes poner una Fecha valida");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner una Fecha");
        }
    }


    public class ValidacionCantidad : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int cantidad = 0;
                try
                {
                    cantidad = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (cantidad >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }

    public class ValidacionProductoId : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (id >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }
}
