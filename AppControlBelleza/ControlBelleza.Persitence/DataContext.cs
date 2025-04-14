using ControlBelleza.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlBelleza.ControlBelleza.Persitence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Estilista> Estilista { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Citas> Citas { get; set; }

        // Nuevas entidades para el sistema de facturación
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetallePago> DetallesPago { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Citas y Facturas (1:1)
            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Factura)
                .WithOne(f => f.Cita)
                .HasForeignKey<Factura>(f => f.CitaId);

            // Configuración de la relación entre Factura y DetallesPago (1:N)
            modelBuilder.Entity<Factura>()
                .HasMany(f => f.DetallesPago)
                .WithOne(d => d.Factura)
                .HasForeignKey(d => d.FacturaId);

            // Configuración de la relación entre MetodoPago y DetallesPago (1:N)
            modelBuilder.Entity<MetodoPago>()
                .HasMany(m => m.DetallesPago)
                .WithOne(d => d.MetodoPago)
                .HasForeignKey(d => d.MetodoPagoId);
        }
    }
}