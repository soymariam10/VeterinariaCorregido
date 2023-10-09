using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;

    public class VeterinariaCorregidoContext : DbContext
    {
        public VeterinariaCorregidoContext(DbContextOptions<VeterinariaCorregidoContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Mascota> Mascostas { get; set; }
        public DbSet<Raza> Razas { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ClienteDireccion> ClienteDireccion { get; set; }
        public DbSet<ClienteTelefono> ClientesTelefonos { get; set; }
        public DbSet<Cita> Citas { get; set; }

        //esto permite la creacion de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
