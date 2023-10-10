using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Cita");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(p => p.Fecha)
        .HasColumnName("Fecha")
        .HasColumnType ("date")
        .IsRequired();

        builder.Property(p => p.Hora)
        .HasColumnName("Hora")
        .IsRequired();

        //relacion de uno a muchos
        builder.HasOne(t => t.Clientes)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.IdCliente);

        //relacion de uno a muchos
        builder.HasOne(t => t.Mascotas)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.IdMascota);

        //relacion de uno a muchos
        builder.HasOne(t => t.Servicios)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.IdServicio);
        
    }
}
