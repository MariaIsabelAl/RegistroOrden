using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ordenes.Entidades;

namespace Ordenes.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Orden> Orden { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DAL\DATA\OrdenDetalles.db");
        }
    }
}
