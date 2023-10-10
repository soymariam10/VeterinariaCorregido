
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class VeterinariaContext : DbContext
{
    public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
    {

    }

    public DbSet<Cita> ? Citas { get; set;}
    public DbSet<Ciudad>? Ciudades { get; set;}
    public DbSet<Cliente> ? Clientes { get; set;}
    public DbSet<ClienteDireccion> ? ClientesDirecciones { get; set; }
    public DbSet<ClienteTelefono>? ClientesTelefonos { get; set; }
    public DbSet<Departamento> ? Departamentos { get; set; }
    public DbSet<Mascota> ? Mascotas { get; set; }
    public DbSet<Pais> ? Paises { get; set; }
    public DbSet<Raza> ? Razas { get; set; }
    public DbSet<Servicio> ? Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //para definir llaves primarias compuestas foraneas  
        //modelBuilder.Entity<MedicamentoProveedor>().HasKey(p => new {p.Id_proveedor , p.Id_medicamento});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
