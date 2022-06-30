using Microsoft.EntityFrameworkCore;
using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Cliente>()
          .Property(b => b.estado)
          .HasDefaultValue(true);

      modelBuilder.Entity<Cuenta>()
          .Property(b => b.estado)
          .HasDefaultValue(true);

      modelBuilder.Entity<Movimiento>()
          .Property(b => b.estado)
          .HasDefaultValue(true);

      modelBuilder.Entity<Movimiento>()
          .HasOne(e => e.Cuenta)
          .WithMany()
          .OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<TipoCuenta>()
            .HasData(
            new TipoCuenta
            {
              tipoCuentaId = 1,
              nombre = "Ahorro",
              estado = true
            },
            new TipoCuenta
            {
              tipoCuentaId = 2,
              nombre = "Corriente",
              estado = true
            });
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<TipoCuenta> TiposCuentas { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }
  }
}