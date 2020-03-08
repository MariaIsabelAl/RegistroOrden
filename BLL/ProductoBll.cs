using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ordenes.DAL;
using Ordenes.Entidades;

namespace Ordenes.BLL
{
    public class ProductoBll
    {
        public static bool Guardar(Producto producto)//Guardar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Producto.Add(producto) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Producto Buscar(int id)//            buscar por id
        {
            Contexto contexto = new Contexto();
            Producto producto = new Producto();

            try
            {
                producto = contexto.Producto.Find(id);

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }
        public static bool Modificar(Producto producto)//modificar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenDetalle Where ProductoId={producto.ProductoId}");
                foreach (var item in producto.OrdenDetalle)
                {

                    contexto.Entry(item).State = EntityState.Added;
                }


                contexto.Entry(producto).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static bool Eliminar(int id)//            Eliminar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Producto.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }//                                  fin




        public static List<Producto> GetList(Expression<Func<Producto, bool>> producto) //               listar
        {
            List<Producto> lista = new List<Producto>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Producto.Where(producto).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Calculo(int id, int cantidad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Producto producto = new Producto();
            producto = contexto.Producto.Find(id);

            if (producto != null)
            {
                try
                {
                    if (producto.Inventario >= 0)
                        producto.Inventario = (producto.Inventario - cantidad);


                    contexto.Entry(producto).State = EntityState.Modified;
                    paso = (contexto.SaveChanges() > 0);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
            }

            return paso;

        }
    }
}
