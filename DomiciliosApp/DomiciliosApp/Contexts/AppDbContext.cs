using DomiciliosApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomiciliosApp.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string DbPath = string.Empty;
        public AppDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        #region ListaDeDatos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        #endregion

        #region Configuracion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tienda>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioID);

            modelBuilder.Entity<Producto>()
                .HasOne(e => e.Tienda)
                .WithMany()
                .HasForeignKey(e => e.TiendaID);

            modelBuilder.Entity<Compra>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioID);

            modelBuilder.Entity<Compra>()
                .HasOne(e => e.Producto)
                .WithMany()
                .HasForeignKey(e => e.ProductoID);
        }
        #endregion
    }
}
