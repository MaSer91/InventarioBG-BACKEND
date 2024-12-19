using InventarioBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InventarioBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definición de las tablas en la base de datos
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        // Configuración adicional de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Product
            modelBuilder.Entity<Product>()
                .ToTable("Productos")
                .Property(p => p.ProductId)
                .HasColumnName("ProductoID");

            modelBuilder.Entity<Product>()
                .ToTable("Productos")
                .Property(p => p.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                .ToTable("Productos")
                .Property(p => p.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(1000);

            modelBuilder.Entity<Product>()
                .ToTable("Productos")
                .Property(p => p.Status)
                .HasColumnName("Estado")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Product>()
                .ToTable("Productos")
                .Property(p => p.Price)
                .HasColumnName("Precio");

            // Configuración de la entidad User
            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.UserId)
                .HasColumnName("UsuarioID");

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.Username)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.Password)
                .HasColumnName("Contrasena")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.FullName)
                .HasColumnName("NombreCompleto")
                .HasMaxLength(500);

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.Gender)
                .HasColumnName("Sexo")
                .HasMaxLength(1);

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.DateOfBirth)
                .HasColumnName("FechaNacimiento");

            modelBuilder.Entity<User>()
                .ToTable("Usuarios")
                .Property(u => u.CreatedAt)
                .HasColumnName("FechaCreacion");

            // Se pueden añadir más configuraciones aquí según las necesidades
        }
    }
}
