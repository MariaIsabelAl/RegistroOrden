using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ordenes.DAL;
using Ordenes.Entidades;
using Ordenes.UI.Registros;

namespace Ordenes.BLL
{
    public class OrdenBll
    {
        public static bool Guardar(Orden orden)//Guardar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Orden.Add(orden) != null)
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

        public static Orden Buscar(int id)//            buscar
        {
            Contexto contexto = new Contexto();
            Orden orden = new Orden();

            try
            {
                orden = contexto.Orden.Include(x => x.OrdenDetalle)
                    .Where(p => p.OrdenId == id)
                    .SingleOrDefault();

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return orden;
        }
        public static bool Modificar(Orden orden)//modificar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenDetalle Where OrdenId={orden.OrdenId}");
                contexto.Entry(orden).State = EntityState.Modified;
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
                var eliminar = contexto.Orden.Find(id);
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
        }




        public static List<Orden> GetList(Expression<Func<Orden, bool>> orden) //               listar
        {
            List<Orden> lista = new List<Orden>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Orden.Where(orden).ToList();
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
    }
}
