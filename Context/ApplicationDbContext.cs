using System.Data;
using Microsoft.EntityFrameworkCore;
using PruebaConcesionario.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PruebaConcesionario.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }
        
        public DbSet<Compania> Companias { get; set; }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Moto> Moto { get; set; }
        public DbSet<TiposFreno> TiposFreno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.VehiculoID);

                entity.Property(e => e.NumeroPuertas);

                entity.Property(e => e.TipoCombustible)
                      .HasMaxLength(50);

                entity.Property(e => e.TipoTransmision)
                      .HasMaxLength(50);

                entity.HasOne(e => e.Vehiculo)
                      .WithOne()
                      .HasForeignKey<Carro>(e => e.VehiculoID);
            });
             
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.HasKey(e => e.VehiculoID);

                entity.Property(e => e.Cilindraje);

                entity.HasOne(e => e.Vehiculo)
                      .WithOne()
                      .HasForeignKey<Moto>(e => e.VehiculoID);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VehiculoID);

                entity.Property(e => e.Marca)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Estado)
                       .IsRequired();

                entity.Property(e => e.Modelo)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Ano)
                      .IsRequired();

                entity.Property(e => e.Color)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Kilometraje)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Imagen);

                entity.Property(e => e.Valor)
                      .IsRequired();

                entity.Property(e => e.FechaDeRegistro)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.TiposFreno)
                      .WithMany()
                      .HasForeignKey(e => e.FrenoID);

                entity.HasOne(e => e.Empleado)
                      .WithMany()
                      .HasForeignKey(e => e.EmpleadoID);
            });

            modelBuilder.Entity<TiposFreno>(entity =>
            {
                entity.HasKey(e => e.FrenoID);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(255);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.EmpleadoID);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Compania>(entity =>
            {
                entity.HasKey(e => e.CompaniaID);

                entity.Property(e => e.Nit)
                      .IsRequired()
                      .HasMaxLength(50); // Define el tamaño máximo del campo

                entity.Property(e => e.RazonSocial)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()"); // Establece un valor predeterminado en la base de datos
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioID);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.TipoIdentificacion)
                      .IsRequired();

                entity.Property(e => e.Identificacion)
                      .IsRequired() 
                      .HasMaxLength(20);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.FechaModificacion);
            });

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Identificacion)
                .IsUnique();

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioID);
            });
             
            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.Property(ti => ti.Descripcion)
                    .IsRequired()   
                    .HasMaxLength(100);   
            });
        }

    }
}
